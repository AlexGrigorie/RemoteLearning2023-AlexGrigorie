using Moq;
<<<<<<< HEAD
using VendingMachine_Business.Exceptions;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Stock;
using VendingMachine_Business.Reports.Volume;
using VendingMachine_Business.UseCases;
=======
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Stock;
using VendingMachine.Business.Reports.Volume;
using VendingMachine.Business.UseCases;
>>>>>>> main

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class VolumeUseCaseTests
    {
        private Mock<ISalesRepository> mockSalesRepository;
        private Mock<IReportsView> mockReportsView;
<<<<<<< HEAD
        private Mock<ILoggerService> mockLoggerService;
=======
>>>>>>> main
        private Mock<IFileSerialization> mockFileSerialization;
        private VolumeReportUseCase volumeReportUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockSalesRepository = new Mock<ISalesRepository>();
            mockReportsView = new Mock<IReportsView>();
            mockFileSerialization = new Mock<IFileSerialization>();
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            volumeReportUseCase = new VolumeReportUseCase(mockSalesRepository.Object, mockReportsView.Object, mockFileSerialization.Object, mockLoggerService.Object);
=======
            volumeReportUseCase = new VolumeReportUseCase(mockSalesRepository.Object, mockReportsView.Object, mockFileSerialization.Object);
>>>>>>> main
        }
        [TestMethod]
        public void HavingVolumeReportUseCase_WhenExecuteWithValidDates_ThenCallsReportsViewAndSerialization()
        {
            TimeInterval timeInterval = new TimeInterval { StartDate = new DateTime(2023, 1, 4), EndDate = new DateTime(2023, 6, 13) };
<<<<<<< HEAD
            var sales = new List<Product>
            {
                new Product { Name = "Orange", Quantity = 13 },
                new Product { Name = "Grape", Quantity = 6 },
                new Product { Name = "Banana", Quantity = 98 },
=======
            var sales = new List<StockProduct>
            {
                new StockProduct { Name = "Orange", Quantity = 13 },
                new StockProduct { Name = "Grape", Quantity = 6 },
                new StockProduct { Name = "Banana", Quantity = 98 },
>>>>>>> main
            };
            mockReportsView.Setup(mrw => mrw.AskForTimeInterval());
            mockReportsView.Setup(mrw => mrw.AskForStartDate()).Returns(new DateTime(2023, 1, 4));
            mockReportsView.Setup(mrw => mrw.AskForEndDate()).Returns(new DateTime(2023, 6, 13));
            mockFileSerialization.Setup(mfs => mfs.Serilizer(It.IsAny<VolumeReport>(), It.IsAny<string>()));
<<<<<<< HEAD
            mockSalesRepository.Setup(msp => msp.GetGroupedByProduct(timeInterval)).Returns(sales);
=======
            mockSalesRepository.Setup(msp => msp.GetProductsBySpecificPeriod(timeInterval)).Returns(sales);
>>>>>>> main
            volumeReportUseCase.Execute();
            mockReportsView.Verify(mrw => mrw.AskForTimeInterval(), Times.Once);
            mockReportsView.Verify(mrw => mrw.AskForStartDate(), Times.Once);
            mockReportsView.Verify(mrw => mrw.AskForEndDate(), Times.Once);
            mockFileSerialization.Verify(mfs => mfs.Serilizer(It.IsAny<VolumeReport>(), It.IsAny<string>()), Times.Once);
        }
        [TestMethod]
        public void HavingVolumeReportUseCase_WhenExecuteWithConflictingDates_ThrowsException()
        {
            mockReportsView.Setup(mrw => mrw.AskForTimeInterval());
            mockReportsView.Setup(mrw => mrw.AskForStartDate()).Returns(new DateTime(2023, 7, 4));
            mockReportsView.Setup(mrw => mrw.AskForEndDate()).Returns(new DateTime(2023, 6, 13));
            Assert.ThrowsException<ConflictDatesException>(() => volumeReportUseCase.Execute());
        }
    }
}
