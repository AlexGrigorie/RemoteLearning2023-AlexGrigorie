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
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 1 };
            int decreaseProductQuantity = apple.Quantity - 1;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act
            buy.Execute();

            //Assert
            mockBuyView.Verify(b => b.DispenseProduct(apple.Name), Times.Once);
            Assert.AreEqual(decreaseProductQuantity, apple.Quantity);
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteEmptyString_ThenThrowCancelException()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            int productId = 0;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(productId);

            //Act & Assert
            Assert.ThrowsException<CancelException>(() => buy.Execute());
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInvalidColumn_ThenThrowInvalidColumnException()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            int productId = 111;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(productId);
            Product product = null;
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == productId))).Returns(product);

            //Act & Assert
            Assert.ThrowsException<InvalidColumnException>(() => buy.Execute());
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInsufficientStock_ThenThrowInsufficientStockException()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buy = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 0 };

            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act & Assert
            Assert.ThrowsException<InsufficientStockException>(() => buy.Execute());
        }
    }
}
