using VendingMachine_Business.Entities;
using VendingMachine_Business.Interfaces;
namespace VendingMachine_Business.UseCases
{
    internal class SupplyExistingProductUseCase : IUseCase
    {
        private const string customMessageIncreaseProduct = "User increased the product quantity.";
        private readonly IProductRepository productRepository;
        private readonly ISupplyProducView supplyProducView;
        private readonly ILoggerService loggerService;
        public SupplyExistingProductUseCase(ISupplyProducView supplyProducView, IProductRepository productRepository, ILoggerService loggerService)
        {
            this.supplyProducView = supplyProducView ?? throw new ArgumentNullException(nameof(supplyProducView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        public void Execute()
        {
            loggerService.LogInformation(customMessageIncreaseProduct);
            QuantitySupply quantitySupply = supplyProducView.RequestProductQuantity();
            productRepository.IncreaseQuantity(quantitySupply);
            supplyProducView.DisplaySuccessMessage();
        }
    }
}
