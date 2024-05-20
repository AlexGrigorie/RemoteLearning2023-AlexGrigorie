using Moq;
using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class SupplyNewProductUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<ISupplyProducView> mockSupplyProductView;
        private SupplyNewProductUseCase supplyNewProductUse;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockSupplyProductView = new Mock<ISupplyProducView>();
            supplyNewProductUse = new SupplyNewProductUseCase(mockProductRepository.Object, mockSupplyProductView.Object);
        }
        [TestMethod]
        public void HavingSupplyExistingProductUseCase_WhenExecute_ThenIncreaseQuantity()
        {
            var product = new Product { ColumnId = 12, Name="Orange", Price=2, Quantity = 13 };
            mockSupplyProductView.Setup(msp => msp.GetNewProduct()).Returns(product);
            mockProductRepository.Setup(mpr => mpr.AddProduct(product));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyNewProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.GetNewProduct(), Times.Once);
            mockSupplyProductView.Verify(msp => msp.DisplaySuccessMessage(), Times.Once);
            mockProductRepository.Verify(mpr => mpr.AddProduct(product), Times.Once);
        }
    }
}
