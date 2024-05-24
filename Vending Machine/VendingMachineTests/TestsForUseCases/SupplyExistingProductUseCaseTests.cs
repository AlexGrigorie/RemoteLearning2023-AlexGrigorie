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
    public class SupplyExistingProductUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<ISupplyProducView> mockSupplyProductView;
<<<<<<< HEAD
        private Mock<ILoggerService> mockLoggerService;
=======
>>>>>>> main
        private SupplyExistingProductUseCase supplyExistingProductUse;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockSupplyProductView = new Mock<ISupplyProducView>();
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            supplyExistingProductUse = new SupplyExistingProductUseCase(mockSupplyProductView.Object, mockProductRepository.Object, mockLoggerService.Object);
=======
            supplyExistingProductUse = new SupplyExistingProductUseCase(mockSupplyProductView.Object, mockProductRepository.Object);
>>>>>>> main
        }
        [TestMethod]
        public void HavingSupplyExistingProductUseCase_WhenExecute_ThenIncreaseQuantity() 
        {
            QuantitySupply quantitySupply = new QuantitySupply {ColumnId =12, Quantity = 13 };
<<<<<<< HEAD
            mockSupplyProductView.Setup(msp => msp.RequestProductQuantity()).Returns(quantitySupply);
            mockProductRepository.Setup(mpr => mpr.IncreaseQuantity(quantitySupply));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyExistingProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.RequestProductQuantity(), Times.Once);
=======
            mockSupplyProductView.Setup(msp => msp.GetProductQuantity()).Returns(quantitySupply);
            mockProductRepository.Setup(mpr => mpr.IncreaseQuantity(quantitySupply));
            mockSupplyProductView.Setup(msp => msp.DisplaySuccessMessage());
            supplyExistingProductUse.Execute();
            mockSupplyProductView.Verify(msp => msp.GetProductQuantity(), Times.Once);
>>>>>>> main
            mockSupplyProductView.Verify(msp => msp.DisplaySuccessMessage(), Times.Once);
            mockProductRepository.Verify(mpr => mpr.IncreaseQuantity(quantitySupply), Times.Once);
        }
    }
}
