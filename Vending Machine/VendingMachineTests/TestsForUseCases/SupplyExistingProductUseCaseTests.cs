using Moq;
using VendingMachine_Business.Entities;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.UseCases;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class SupplyExistingProductUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<ISupplyProducView> mockSupplyProductView;
        private SupplyExistingProductUseCase supplyExistingProductUse;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockSupplyProductView = new Mock<ISupplyProducView>();
            supplyExistingProductUse = new SupplyExistingProductUseCase(mockSupplyProductView.Object, mockProductRepository.Object);
        }
        [TestMethod]
        public void HavingSupplyExistingProductUseCase_WhenExecute_ThenIncreaseQuantity() 
        {
            QuantitySupply quantitySupply = new QuantitySupply {ColumnId =12, Quantity = 13 };
            mockSupplyProductView.Setup(msp => msp.RequestProductQuantity()).Returns(quantitySupply);
            mockProductRepository.Setup(mpr => mpr.IncreaseQuantity(quantitySupply));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyExistingProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.RequestProductQuantity(), Times.Once);
            mockSupplyProductView.Verify(msp => msp.DisplaySuccessMessage(), Times.Once);
            mockProductRepository.Verify(mpr => mpr.IncreaseQuantity(quantitySupply), Times.Once);
        }
    }
}
