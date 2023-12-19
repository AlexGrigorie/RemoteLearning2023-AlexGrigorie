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
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IVendingMachineApplication> mockVendingMachine;
        private Mock<IBuyView> mockBuyView;
        private BuyUseCase buyUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockVendingMachine = new Mock<IVendingMachineApplication>();
            mockBuyView = new Mock<IBuyView>();
            buyUseCase = new BuyUseCase(mockVendingMachine.Object, mockBuyView.Object, mockProductRepository.Object);
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenName_DisplayCorrectValue()
        {
            //Act
            string name = buyUseCase.Name;

            //Assert
            Assert.AreEqual("buy", name);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Act
            string description = buyUseCase.Description;

            //Assert
            Assert.AreEqual("Buy your favourite product", description);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenNoAdminIsLogin_CanExecuteIsTrue()
        {
            //Arrange
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, false);

            //Act
            bool canExecute = buyUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenAdminIsLogin_CanExecuteIsFalse()
        {
            //Arrange
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);

            //Act
            bool canExecute = buyUseCase.CanExecute;

            //Assert
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteValidProductId_ThenDispenseProduct()
        {
            //Arrange
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
            int productId = 0;
            mockBuyView.Setup(b => b.RequestProduct()).Returns(productId);

            //Act & Assert
            Assert.ThrowsException<CancelException>(() => buyUseCase.Execute());
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInvalidColumn_ThenThrowInvalidColumnException()
        {
            //Arrange
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
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 0 };

            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);

            //Act & Assert
            Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
        }
    }
}
