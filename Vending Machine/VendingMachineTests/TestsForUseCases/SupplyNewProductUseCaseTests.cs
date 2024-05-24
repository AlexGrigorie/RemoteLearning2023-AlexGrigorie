using Moq;
<<<<<<< HEAD
using VendingMachine_Business.Entities;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.UseCases;
=======
using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;
>>>>>>> main

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class SupplyNewProductUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<ISupplyProducView> mockSupplyProductView;
<<<<<<< HEAD
        private Mock<ILoggerService> mockLoggerService;
=======
>>>>>>> main
        private SupplyNewProductUseCase supplyNewProductUse;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockSupplyProductView = new Mock<ISupplyProducView>();
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            supplyNewProductUse = new SupplyNewProductUseCase(mockProductRepository.Object, mockSupplyProductView.Object, mockLoggerService.Object);
=======
            supplyNewProductUse = new SupplyNewProductUseCase(mockProductRepository.Object, mockSupplyProductView.Object);
>>>>>>> main
        }
        [TestMethod]
        public void HavingSupplyExistingProductUseCase_WhenExecute_ThenIncreaseQuantity()
        {
            var product = new Product { ColumnId = 12, Name="Orange", Price=2, Quantity = 13 };
<<<<<<< HEAD
            mockSupplyProductView.Setup(msp => msp.RequestNewProduct()).Returns(product);
            mockProductRepository.Setup(mpr => mpr.AddOrReplace(product));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyNewProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.RequestNewProduct(), Times.Once);
            mockSupplyProductView.Verify(msp => msp.DisplaySuccessMessage(), Times.Once);
            mockProductRepository.Verify(mpr => mpr.AddOrReplace(product), Times.Once);
=======
            mockSupplyProductView.Setup(msp => msp.GetNewProduct()).Returns(product);
            mockProductRepository.Setup(mpr => mpr.AddProduct(product));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyNewProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.GetNewProduct(), Times.Once);
            mockSupplyProductView.Verify(msp => msp.DisplaySuccessMessage(), Times.Once);
            mockProductRepository.Verify(mpr => mpr.AddProduct(product), Times.Once);
>>>>>>> main
        }
    }
}
