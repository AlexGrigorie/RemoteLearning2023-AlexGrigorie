using VendingMachine_Business.Interfaces;

namespace VendingMachine_Business.UseCases
{
    internal class SupplyNewProductUseCase : IUseCase
    {
        private const string customMessageSupply = "User added or replaced a product.";
        private readonly IProductRepository productRepository;
        private readonly ISupplyProducView supplyProducView;
        private readonly ILoggerService loggerService;
        public SupplyNewProductUseCase(IProductRepository productRepository, ISupplyProducView supplyProducView, ILoggerService loggerService)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.supplyProducView = supplyProducView ?? throw new ArgumentNullException(nameof(supplyProducView)); 
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        public void Execute()
        {
            loggerService.LogInformation(customMessageSupply);
            var product = supplyProducView.RequestNewProduct();
            productRepository.AddOrReplace(product);
            supplyProducView.DisplaySuccessMessage();
        }
    }
}
