using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.Models.Enums;
using ParkingExpert.Services.Abstractions;

namespace ParkingExpert.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportService _reportService;

        public ReportsController(ILogger<ReportsController> logger, 
            IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        [HttpGet("[action]")]
        public IActionResult Generate(ReportType reportType)
        {
            var items = _reportService.Generate(reportType);
            return Ok(items);
        }
    }
}