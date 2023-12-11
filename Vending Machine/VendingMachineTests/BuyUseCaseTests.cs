using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachineTests
{
    [TestClass]
    public class BuyUseCaseTests
    {
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteValidProductId_ThenDispenseProduct()
        {
            //Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var vendingMachineMock = new Mock<IVendingMachineApplication>();
            var buyViewMock = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(vendingMachineMock.Object, buyViewMock.Object, productRepositoryMock.Object);
            Product apple = new Product();
            apple.ColumnId = 11;
            apple.Name = "Apple";
            apple.Price = 2;
            apple.Quantity = 1;

            buyViewMock.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            productRepositoryMock.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act
            buy.Execute();

            //Assert
            buyViewMock.Verify(b => b.DispenseProduct(apple.Name), Times.Once);
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteEmptyString_ThenThrowCancelException()
        {
            //Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var vendingMachineMock = new Mock<IVendingMachineApplication>();
            var buyViewMock = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(vendingMachineMock.Object, buyViewMock.Object, productRepositoryMock.Object);
            int productId = 0;

            buyViewMock.Setup(b => b.RequestProduct()).Returns(productId);

            //Act & Assert
            Assert.ThrowsException<CancelException>(() => buy.Execute());
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInvalidColumn_ThenThrowInvalidColumnException()
        {
            //Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var vendingMachineMock = new Mock<IVendingMachineApplication>();
            var buyViewMock = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(vendingMachineMock.Object, buyViewMock.Object, productRepositoryMock.Object);
            int productId = 111;

            buyViewMock.Setup(b => b.RequestProduct()).Returns(productId);
            Product product = null;
            productRepositoryMock.Setup(p => p.GetByColumn(It.Is<int>(f => f == productId))).Returns(product);

            //Act & Assert
            Assert.ThrowsException<InvalidColumnException>(() => buy.Execute());
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInsufficientStock_ThenThrowInsufficientStockException()
        {
            //Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var vendingMachineMock = new Mock<IVendingMachineApplication>();
            var buyViewMock = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(vendingMachineMock.Object, buyViewMock.Object, productRepositoryMock.Object);
            Product apple = new Product();
            apple.ColumnId = 11;
            apple.Name = "Apple";
            apple.Price = 2;
            apple.Quantity = 0;

            buyViewMock.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            productRepositoryMock.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act & Assert
            Assert.ThrowsException<InsufficientStockException>(() => buy.Execute());
        }
    }
}
