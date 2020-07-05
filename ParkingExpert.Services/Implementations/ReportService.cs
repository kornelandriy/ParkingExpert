using System;
using System.Collections.Generic;
using System.Linq;
using ParkingExpert.Models.Enums;
using ParkingExpert.Models.Models.Dtos;
using ParkingExpert.Repositories.Abstractions;
using ParkingExpert.Services.Abstractions;
using ParkingExpert.Services.Helpers;
using ParkingPlace = ParkingExpert.DB.Entities.ParkingPlace;

namespace ParkingExpert.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ParkingPlace> _parkingPlaces;

        public ReportService(IRepository<ParkingPlace> parkingPlaces)
        {
            _parkingPlaces = parkingPlaces;
        }

        public List<ReportRow> Generate(ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.Month:
                    return MonthlyReport();
                case ReportType.Quarter:
                    return QuarterlyReport();
                case ReportType.Year:
                    return YearlyReport();
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportType), reportType, null);
            }
        }

        private List<ReportRow> QuarterlyReport()
        {
            var query = 
                (from row in _parkingPlaces.GetAll()
                        .Where(x => x.DepartureAt.HasValue)
                        .OrderBy(x => x.DepartureAt)
                    group row by new
                    {
                        Year = row.DepartureAt.Value.Year,
                        Quarter = (row.DepartureAt.Value.Month - 1) / 3
                    } into g
                    select new ReportRow
                    {
                        Period = $"{g.Key.Quarter.ToQuarter()} ({g.Key.Year})",
                        Income = g.Sum(x => x.PayedAmount),
                        Cars = g.Count()
                    })
                .ToList();
            return query;
        }

        private List<ReportRow> YearlyReport()
        {
            var query = 
                (from row in _parkingPlaces.GetAll()
                        .Where(x => x.DepartureAt.HasValue)
                        .OrderBy(x => x.DepartureAt)
                    group row by row.DepartureAt.Value.Year into g
                    select new ReportRow
                    {
                        Period = g.Key.ToString(),
                        Income = g.Sum(x => x.PayedAmount),
                        Cars = g.Count()
                    })
                .ToList();
            return query;
        }

        private List<ReportRow> MonthlyReport()
        {
            var query = 
                (from row in _parkingPlaces.GetAll()
                        .Where(x => x.DepartureAt.HasValue)
                        .OrderBy(x => x.DepartureAt)
                    group row by new
                    {
                        Year = row.DepartureAt.Value.Year,
                        Month = row.DepartureAt.Value.Month
                    } into g
                select new ReportRow
                {
                    Period = $"{g.Key.Month.ToMonth()} ({g.Key.Year})",
                    Income = g.Sum(x => x.PayedAmount),
                    Cars = g.Count()
                })
                .ToList();
            return query;
        }
    }
}