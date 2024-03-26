using VendingMachine_Business.Interfaces;

namespace VendingMachine_Business.UseCases
{
    internal class SupplyNewProductUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplyProducView supplyProducView;
        public SupplyNewProductUseCase(IProductRepository productRepository, ISupplyProducView supplyProducView)
        {
            this.productRepository = productRepository;
            this.supplyProducView = supplyProducView;
        }
        public void Execute()
        {
            var product = supplyProducView.RequestNewProduct();
            productRepository.AddOrReplace(product);
            supplyProducView.DisplaySuccessMessage();
        }
    }
}
