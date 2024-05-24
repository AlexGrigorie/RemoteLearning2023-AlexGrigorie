using Moq;
<<<<<<< HEAD
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Stock;
using VendingMachine_Business.UseCases;
using Product = VendingMachine_Business.Entities.Product;
=======
using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Stock;
using VendingMachine.Business.UseCases;
>>>>>>> main

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class StockReportUseCaseTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IReportsView> mockReportsView;
        private Mock<IFileSerialization> mockFileSerialization;
<<<<<<< HEAD
        private Mock<ILoggerService> mockLoggerService;
=======
>>>>>>> main
        private StockReportUseCase stockReportUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockReportsView = new Mock<IReportsView>();
            mockFileSerialization = new Mock<IFileSerialization>();
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            stockReportUseCase = new StockReportUseCase(mockFileSerialization.Object, mockProductRepository.Object, mockReportsView.Object, mockLoggerService.Object);
=======
            stockReportUseCase = new StockReportUseCase(mockFileSerialization.Object, mockProductRepository.Object, mockReportsView.Object);
>>>>>>> main
        }

        [TestMethod]
        public void HavingStockReportUseCase_WhenExecute_ThenCallsReportsViewAndSerialization()
        {
            var stockReport = new List<Product>
            {
                new Product { Name = "Orange", Quantity = 13 },
                new Product { Name = "Grape", Quantity = 6 },
                new Product { Name = "Banana", Quantity = 98 },
            };

            mockProductRepository.Setup(mpr => mpr.GetAll()).Returns(stockReport);
            mockReportsView.Setup(mrw => mrw.DisplayCurrentDateTime()).Returns(DateTime.Now.ToString());
            stockReportUseCase.Execute();
            mockProductRepository.Verify(mpr => mpr.GetAll(), Times.Once);
            mockFileSerialization.Verify(mfs => mfs.Serilizer(It.IsAny<StockReport>(), It.IsAny<string>()), Times.Once);
            mockReportsView.Verify(mrw => mrw.DisplaySuccessMessage(), Times.Once);
        }
    }
}
