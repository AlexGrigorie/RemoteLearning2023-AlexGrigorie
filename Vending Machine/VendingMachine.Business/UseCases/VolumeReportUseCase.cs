﻿using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Volume;

namespace VendingMachine.Business.UseCases
{
    internal class VolumeReportUseCase : IUseCase
    {
        private readonly ISalesRepository salesRepository;
        private readonly IReportsView reportsView;
        private readonly IFileSerialization fileSerialization;

        public VolumeReportUseCase(ISalesRepository salesRepository, IReportsView reportsView, IFileSerialization fileSerialization)
        {
            this.salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
            this.fileSerialization = fileSerialization ?? throw new ArgumentNullException(nameof(fileSerialization));
        }

        public void Execute()
        {
            reportsView.AskForTimeInterval();
            TimeInterval timeInterval = new TimeInterval();
            timeInterval.StartDate = reportsView.AskForStartDate().Date;
            timeInterval.EndDate = reportsView.AskForEndDate().Date;

            if (!ConflictWith(timeInterval))
            {
                var salesProducts = salesRepository.GetProductsBySpecificPeriod(timeInterval);
                var volumeProducts = new VolumeReport{ StartDate = timeInterval.StartDate, EndDate = timeInterval.EndDate, Sales = salesProducts.ToList() };
                fileSerialization.Serilizer(volumeProducts, $"Volume Report - {reportsView.DisplayCurrentDateTime()}");
                reportsView.DisplaySuccessMessage();
            }
            else
                throw new ConflictDatesException();
        }

        private bool ConflictWith(TimeInterval timeInterval)
        {
            return timeInterval.StartDate > timeInterval.EndDate;
        }
    }
}
