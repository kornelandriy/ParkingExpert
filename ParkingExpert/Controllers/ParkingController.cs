using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.Services.Abstractions;

namespace ParkingExpert.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> _logger;
        private readonly IParkingService _parkingService;
        private readonly IPaymentService _paymentService;

        public ParkingController(ILogger<ParkingController> logger, 
            IParkingService parkingService, 
            IPaymentService paymentService)
        {
            _logger = logger;
            _parkingService = parkingService;
            _paymentService = paymentService;
        }

        [HttpGet("[action]")]
        public IActionResult Enter(string carPlate)
        {
            if (_parkingService.IsInParking(carPlate))
            {
                _logger.LogError($"Not allowed to enter car with plate: {carPlate}");
                return BadRequest($"Not allowed to enter car with plate: {carPlate}");
            }

            _parkingService.AddToParking(carPlate);
            _logger.LogInformation($"Car with plate: {carPlate} was added to the parking.");
            return Ok($"Car with plate: {carPlate} was added to the parking.");
        }
        
        [HttpGet("[action]")]
        public IActionResult Exit(string carPlate)
        {
            var (canExit, amountToPay) = _paymentService.IsAllowToExit(carPlate);
            if (!canExit)
            {
                _logger.LogError($"Parking is not payed for car with plate: {carPlate}, amount is {amountToPay}");
                return BadRequest($"Parking is not payed for car with plate: {carPlate}, amount is {amountToPay}");
            }

            _parkingService.Exit(carPlate);

            _logger.LogInformation($"Car with plate: {carPlate} exit the parking.");
            return Ok($"Car with plate: {carPlate} exit the parking.");
        }
        
        [HttpGet("[action]")]
        public IActionResult FreeSpots()
        {
            var freeSpots = _parkingService.GetFreeSpots();

            _logger.LogInformation($"Free parking spots: {freeSpots}.");
            return Ok(freeSpots);
        }
    }
}