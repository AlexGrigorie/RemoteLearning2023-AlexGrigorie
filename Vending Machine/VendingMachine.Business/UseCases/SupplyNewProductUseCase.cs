using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.UseCases
{
    internal class SupplyNewProductUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplyProducView supplyProductView;
        public SupplyNewProductUseCase(IProductRepository productRepository, ISupplyProducView supplyProducView)
        {
            this.productRepository = productRepository;
            this.supplyProductView = supplyProducView;
        }
        public void Execute()
        {
            var product = supplyProductView.GetNewProduct();
            productRepository.AddProduct(product);
            supplyProductView.DisplaySuccessMessage();
        }
    }
}
