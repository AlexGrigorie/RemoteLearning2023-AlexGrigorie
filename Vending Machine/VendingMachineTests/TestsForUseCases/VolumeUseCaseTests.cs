using Moq;
using VendingMachine_Business.Exceptions;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Stock;
using VendingMachine_Business.Reports.Volume;
using VendingMachine_Business.UseCases;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class VolumeUseCaseTests
    {
        private Mock<ISalesRepository> mockSalesRepository;
        private Mock<IReportsView> mockReportsView;
        private Mock<ILoggerService> mockLoggerService;
        private Mock<IFileSerialization> mockFileSerialization;
        private VolumeReportUseCase volumeReportUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockSalesRepository = new Mock<ISalesRepository>();
            mockReportsView = new Mock<IReportsView>();
            mockFileSerialization = new Mock<IFileSerialization>();
            mockLoggerService = new Mock<ILoggerService>();
            volumeReportUseCase = new VolumeReportUseCase(mockSalesRepository.Object, mockReportsView.Object, mockFileSerialization.Object, mockLoggerService.Object);
        }
        [TestMethod]
        public void HavingVolumeReportUseCase_WhenExecuteWithValidDates_ThenCallsReportsViewAndSerialization()
        {
            TimeInterval timeInterval = new TimeInterval { StartDate = new DateTime(2023, 1, 4), EndDate = new DateTime(2023, 6, 13) };
            var sales = new List<Product>
            {
                new Product { Name = "Orange", Quantity = 13 },
                new Product { Name = "Grape", Quantity = 6 },
                new Product { Name = "Banana", Quantity = 98 },
            };
            mockReportsView.Setup(mrw => mrw.AskForTimeInterval());
            mockReportsView.Setup(mrw => mrw.AskForStartDate()).Returns(new DateTime(2023, 1, 4));
            mockReportsView.Setup(mrw => mrw.AskForEndDate()).Returns(new DateTime(2023, 6, 13));
            mockFileSerialization.Setup(mfs => mfs.Serilizer(It.IsAny<VolumeReport>(), It.IsAny<string>()));
            mockSalesRepository.Setup(msp => msp.GetGroupedByProduct(timeInterval)).Returns(sales);
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
