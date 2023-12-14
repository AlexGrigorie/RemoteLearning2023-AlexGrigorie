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
        public void HavingBuyUseCase_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);

            //Act
            string name = buyUseCase.Name;

            //Assert
            Assert.AreEqual("buy", name);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);

            //Act
            string description = buyUseCase.Description;

            //Assert
            Assert.AreEqual("Buy your favourite product", description);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenNoAdminIsLogin_CanExecuteIsTrue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockBuyView = new Mock<IBuyView>();

            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, false);
            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);

            //Act
            bool canExecute = buyUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenAdminIsLogin_CanExecuteIsFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockBuyView = new Mock<IBuyView>();

            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);
            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);

            //Act
            bool canExecute = buyUseCase.CanExecute;

            //Assert
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteValidProductId_ThenDispenseProduct()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 1 };
            int decreaseProductQuantity = apple.Quantity - 1;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act
            buyUseCase.Execute();

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

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            int productId = 0;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(productId);

            //Act & Assert
            Assert.ThrowsException<CancelException>(() => buyUseCase.Execute());
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInvalidColumn_ThenThrowInvalidColumnException()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            int productId = 111;

            mockBuyView.Setup(b => b.RequestProduct()).Returns(productId);
            Product product = null;
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == productId))).Returns(product);

            //Act & Assert
            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInsufficientStock_ThenThrowInsufficientStockException()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockBuyView = new Mock<IBuyView>();

            BuyUseCase buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 0 };

            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act & Assert
            Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
        }
    }
}
