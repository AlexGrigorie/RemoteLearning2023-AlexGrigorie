using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LookUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IShelfView> mockShelfView;
        private LookUseCase lookUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockShelfView = new Mock<IShelfView>();
            lookUseCase = new LookUseCase(mockProductRepository.Object, mockShelfView.Object);
        }
        [TestMethod]
        public void HavingLookUseCase_WhenName_DisplayCorrectValue()
        {
            //Act
            string name = lookUseCase.Name;

            //Assert
            Assert.AreEqual("look", name);
        }
        [TestMethod]
        public void HavingLookUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Act
            string description = lookUseCase.Description;

            //Assert
            Assert.AreEqual("Display all available products.", description);
        }
        [TestMethod]
        public void HavingLookUseCase_WhenAnyone_CanExecuteIsTrue()
        {
            //Act
            bool canExecute = lookUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLookUseCase_WhenExecute_ThenDisplayAllProducts()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product {ColumnId = 11, Name= "Grape", Price = 2.99f, Quantity = 12 },
                new Product {ColumnId = 12, Name= "Orange", Price = 2.99f, Quantity = 1 },
                new Product {ColumnId = 13, Name= "Apple", Price = 2.99f, Quantity = 2 },

            };
            mockProductRepository.Setup(p => p.GetAll()).Returns(products);

            //Act
            lookUseCase.Execute();

            //Assert
            mockShelfView.Verify(s => s.DisplayProducts(products), Times.Once);
        }
    }
}
