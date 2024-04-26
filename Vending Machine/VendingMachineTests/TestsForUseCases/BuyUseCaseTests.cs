using Moq;
using VendingMachine_Business;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class BuyUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IBuyView> mockBuyView;
        private Mock<IPaymentUseCase> mockPaymentUsecase;
        private BuyUseCase buyUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockPaymentUsecase = new Mock<IPaymentUseCase>();
            mockBuyView = new Mock<IBuyView>();
            buyUseCase = new BuyUseCase(mockAuthenticationService.Object, mockBuyView.Object,
                mockProductRepository.Object, mockPaymentUsecase.Object);
        }

        [TestMethod]
        public void HavingBuyUseCase__DisplayCorrectName()
        {
            string name = buyUseCase.Name;
            Assert.AreEqual("buy", name);
        }
        [TestMethod]
        public void HavingBuyUseCase__DisplayCorrectDescription()
        {
            string description = buyUseCase.Description;
            Assert.AreEqual("Buy your favourite product", description);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenNoAdminIsLogin_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = buyUseCase.CanExecute;
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenAdminIsLogin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = buyUseCase.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteValidProductId_ThenDispenseProduct()
        {
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 1 };
            int decreasedProductQuantity = apple.Quantity - 1;
            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);
            buyUseCase.Execute();
            mockBuyView.Verify(b => b.DispenseProduct(apple.Name), Times.Once);
            Assert.AreEqual(decreasedProductQuantity, apple.Quantity);
        }
        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInvalidColumn_ThenThrowInvalidColumnException()
        {
            int invalidProductId = 111;
            mockBuyView.Setup(b => b.RequestProduct()).Returns(invalidProductId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == invalidProductId))).Returns((Product)null);
            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void HavingBuyUseCase_WhenExecuteInsufficientStock_ThenThrowInsufficientStockException()
        {
            Product apple = new Product { ColumnId = 11, Name = "Apple", Price = 2, Quantity = 0 };
            mockBuyView.Setup(b => b.RequestProduct()).Returns(apple.ColumnId);
            mockProductRepository.Setup(p => p.GetByColumn(It.Is<int>(f => f == apple.ColumnId))).Returns(apple);
            Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
        }
    }
}
