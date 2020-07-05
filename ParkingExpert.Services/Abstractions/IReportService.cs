using System.Collections.Generic;
using ParkingExpert.Models.Enums;
using ParkingExpert.Models.Models.Dtos;

namespace ParkingExpert.Services.Abstractions
{
    public interface IReportService
    {
        List<ReportRow> Generate(ReportType reportType);
    }
}