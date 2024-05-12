using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.UseCases
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
