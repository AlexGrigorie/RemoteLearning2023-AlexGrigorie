using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private const int minimumProductQuantity = 1;
        public string Name => "buy";

        public string Description => "Buy your favourite product";

        public bool CanExecute => !authenticationService.IsUserLoggedIn;

        public BuyUseCase(IAuthenticationService authenticationService, IBuyView buyView, IProductRepository productRepository)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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
            product.Quantity--;
            buyView.DispenseProduct(product.Name);
        }
    }
}
