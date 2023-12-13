using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LookUseCaseTests
    {
        [TestMethod]
        public void HavingLookUseCase_WhenExecute_ThenDisplayAllProducts()
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var mockShelfView = new Mock<IShelfView>();
            LookUseCase look = new LookUseCase(mockProductRepository.Object, mockShelfView.Object);

            var products = new List<Product>
            {
                new Product {ColumnId = 11, Name= "Grape", Price = 2.99f, Quantity = 12 },
                new Product {ColumnId = 12, Name= "Orange", Price = 2.99f, Quantity = 1 },
                new Product {ColumnId = 13, Name= "Apple", Price = 2.99f, Quantity = 2 },

            };
            mockProductRepository.Setup(p => p.GetAll()).Returns(products);

            //Act
            look.Execute();

            //Assert
            mockShelfView.Verify(s => s.DisplayProducts(products), Times.Once);
        }
    }
}
