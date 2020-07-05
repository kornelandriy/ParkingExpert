using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.DB.Entities;
using ParkingExpert.Repositories.Abstractions;

namespace ParkingExpert.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> _logger;
        private readonly IRepository<ParkingPlace> _parkingPlaces;

        public ParkingController(ILogger<ParkingController> logger, IRepository<ParkingPlace> parkingPlaces)
        {
            _logger = logger;
            _parkingPlaces = parkingPlaces;
        }

        [HttpGet("[action]")]
        public IActionResult Enter(string carPlate)
        {
            if (!IsAllowedToEntry(carPlate))
            {
                _logger.LogError($"Not allowed to enter car with plate: {carPlate}");
                return BadRequest($"Not allowed to enter car with plate: {carPlate}");
            }

            var parkingPlace = new ParkingPlace
            {
                ArrivedAt = DateTime.Now, 
                CarPlate = carPlate
            };
            _parkingPlaces.Insert(parkingPlace);
            _logger.LogInformation($"Car with plate: {carPlate} was added to the parking.");
            return Ok($"Car with plate: {carPlate} was added to the parking.");
        }
        
        [HttpGet("[action]")]
        public IActionResult Exit(string carPlate)
        {
            var parkingPlace = _parkingPlaces.GetAll().SingleOrDefault(x => x.CarPlate == carPlate);
            if (parkingPlace == null)
            {
                _logger.LogError($"Car with plate: {carPlate} is not in the parking");
                return BadRequest($"Car with plate: {carPlate} is not in the parking");
            }

            if (parkingPlace.DepartureAt > DateTime.Now)
            {
                parkingPlace.Payed = false;
                _parkingPlaces.Update(parkingPlace);
                _logger.LogError($"Parking is not payed for car with plate: {carPlate}");
                return BadRequest($"Parking is not payed for car with plate: {carPlate}");
            }

            _logger.LogInformation($"Car with plate: {carPlate} exit the parking.");
            return Ok($"Car with plate: {carPlate} exit the parking.");
        }

        private bool IsAllowedToEntry(string carPlate)
        {
            return _parkingPlaces.GetAll().All(x => x.CarPlate != carPlate);
        }
    }
}