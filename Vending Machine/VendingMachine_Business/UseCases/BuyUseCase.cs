using VendingMachine_Business.Entities;

namespace VendingMachine_Business.Interfaces
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IPaymentUseCase paymentUseCase;
        private const int minimumProductQuantity = 1;

        public BuyUseCase(IBuyView buyView, 
            IProductRepository productRepository, IPaymentUseCase paymentUseCase)
        {
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
