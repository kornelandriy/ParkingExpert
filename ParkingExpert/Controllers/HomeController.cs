using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.DB;
using ParkingExpert.DB.Entities;

namespace ParkingExpert.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PEDataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, PEDataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet("[action]")]
        public List<ParkingPlace> Places()
        {
            var list = _dataContext.ParkingPlaces.ToList();
            return list;
        }
    }
}