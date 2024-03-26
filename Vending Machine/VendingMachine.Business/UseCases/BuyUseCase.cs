using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using VendingMachine.Business.Interfaces;
namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IPaymentUseCase paymentUseCase;
        private readonly IAuthenticationService authenticationService;
        private const int minimumProductQuantity = 1;
        public string Name => "buy";

        public string Description => "Buy your favourite product";

        public bool CanExecute => !authenticationService.IsUserLoggedIn;

        public BuyUseCase(IAuthenticationService authenticationService, IBuyView buyView, 
            IProductRepository productRepository, IPaymentUseCase paymentUseCase)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            int productId = buyView.RequestProduct();
            Product product = productRepository.GetByColumn(productId);
            if (product == null)
            {
                throw new InvalidColumnException();
            }
            if (product.Quantity < minimumProductQuantity)
            {
                throw new InsufficientStockException();
            }
            paymentUseCase.Execute(product.Price);
            product.Quantity--;
            buyView.DispenseProduct(product.Name);
        }
    }
}
