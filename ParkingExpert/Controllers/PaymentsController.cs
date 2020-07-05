using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.Services.Abstractions;

namespace ParkingExpert.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentsController(ILogger<PaymentsController> logger, 
            IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet("[action]")]
        public IActionResult AmountToPay(string carPlate)
        {
            var amount = _paymentService.GetAmountToPayByCarPlate(carPlate);
            _logger.LogInformation($"Car with plate: {carPlate} should pay: {amount}");
            return Ok(amount);
        }
        
        [HttpGet("[action]")]
        public IActionResult Pay(string carPlate, decimal amount)
        {
            var amountToPay = _paymentService.GetAmountToPayByCarPlate(carPlate);

            if (amount < amountToPay)
            {
                _logger.LogError($"Amount ot pay for car with plate: {carPlate} is {amountToPay}");
                return BadRequest($"Amount ot pay for car with plate: {carPlate} is {amountToPay}");
            }
          
            var isSucceeded = _paymentService.Pay(carPlate, amount);
            if (!isSucceeded)
            {
                _logger.LogError($"Amount ot pay for car with plate: {carPlate} is {amountToPay}");
                return BadRequest($"Amount ot pay for car with plate: {carPlate} is {amountToPay}"); 
            }

            _logger.LogInformation($"Car with plate: {carPlate} payed {amount}");
            return Ok($"Car with plate: {carPlate} payed {amount}");
        }
    }
}