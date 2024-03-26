using Moq;
using VendingMachine_Business.Entities;
using VendingMachine_Business.Exceptions;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Sales;
using VendingMachine_Business.UseCases;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class SalesReportUseCaseTests
    {
        private Mock<ISalesRepository> mockSalesRepository;
        private Mock<IReportsView> mockReportsView;
        private Mock<IFileSerialization> mockFileSerialization;
        private SalesReportUseCase salesReportUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockSalesRepository = new Mock<ISalesRepository>();
            mockReportsView = new Mock<IReportsView>();
            mockFileSerialization = new Mock<IFileSerialization>();
            salesReportUseCase = new SalesReportUseCase(mockSalesRepository.Object, mockReportsView.Object, mockFileSerialization.Object);
        }
        [TestMethod]
        public void HavingSalesReportUseCase_WhenExecuteWithValidDates_ThenCallsReportsViewAndSerialization()
        {

            var sales = new List<Sales>
            {
                    new Sales
                    {
                         Product = new Product()
                        {
                              ColumnId = 11,
                              Name = "Apple",
                              Price= 2,
                              Quantity = 1,
                        },
                        PaymentMethod = "cash",
                        SaleDate = new DateTime(2023,6,2)
                    },

                    new Sales
                    {
                         Product = new Product()
                        {
                            ColumnId = 12,
                            Name = "Orange",
                            Price = 4,
                            Quantity = 5,
                        },
                         PaymentMethod = "card",
                         SaleDate = new DateTime(2023,1,4)
                    },

                    new Sales
                    {
                         Product = new Product()
                        {
                            ColumnId = 13,
                            Name = "Grape",
                            Price = 2.99f,
                            Quantity = 10,
                        },
                         PaymentMethod = "card",
                         SaleDate = new DateTime(2023,1,6)
                    },

                     new Sales
                    {
                         Product = new Product()
                        {
                            ColumnId = 14,
                            Name = "Banana",
                            Price = 2.5f,
                            Quantity = 7,
                        },
                        PaymentMethod = "card",
                        SaleDate = new DateTime(2022,6,13)
                    },
            };

            mockSalesRepository.Setup(msr => msr.GetAllSales()).Returns(sales);
            mockReportsView.Setup(mrw=> mrw.AskForTimeInterval());
            mockReportsView.Setup(mrw => mrw.AskForStartDate()).Returns(new DateTime(2023, 1, 4));
            mockReportsView.Setup(mrw => mrw.AskForEndDate()).Returns(new DateTime(2023, 6, 13));
            mockFileSerialization.Setup(mfs => mfs.Serilizer(It.IsAny<SalesReports>(), It.IsAny<string>()));
            salesReportUseCase.Execute();
            mockReportsView.Verify(mrw => mrw.AskForTimeInterval(), Times.Once);
            mockReportsView.Verify(mpw => mpw.AskForStartDate(), Times.Once);
            mockReportsView.Verify(mrw => mrw.AskForEndDate(), Times.Once);
            mockFileSerialization.Verify(mfs => mfs.Serilizer(It.IsAny<SalesReports>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingSalesReportUseCase_WhenExecuteWithConflictingDates_ThrowsException()
        {
            mockReportsView.Setup(mrw => mrw.AskForTimeInterval());
            mockReportsView.Setup(mrw => mrw.AskForStartDate()).Returns(new DateTime(2023, 7, 4));
            mockReportsView.Setup(mrw => mrw.AskForEndDate()).Returns(new DateTime(2023, 6, 13));
            Assert.ThrowsException<ConflictDatesException>(() => salesReportUseCase.Execute());
        }
    }
}
