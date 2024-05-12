using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.UseCases
{
    internal class SupplyExistingProductUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplyProducView supplyProducView;
        public SupplyExistingProductUseCase(ISupplyProducView supplyProducView, IProductRepository productRepository)
        {
            this.supplyProducView = supplyProducView;
            this.productRepository = productRepository;
        }
        public void Execute()
        {
            QuantitySupply quantitySupply = supplyProducView.RequestProductQuantity();
            productRepository.IncreaseQuantity(quantitySupply);
            supplyProducView.DisplaySuccessMessage();
        }
    }
}
