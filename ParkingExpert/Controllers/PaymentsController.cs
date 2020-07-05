using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingExpert.Models.Models.Dtos;
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
        
        [HttpPost("[action]")]
        public IActionResult Pay([FromBody]PayModel payModel)
        {
            var amountToPay = _paymentService.GetAmountToPayByCarPlate(payModel.CarPlate);

            if (payModel.Amount < amountToPay)
            {
                _logger.LogError($"Amount ot pay for car with plate: {payModel.CarPlate} is {amountToPay}");
                return BadRequest($"Amount ot pay for car with plate: {payModel.CarPlate} is {amountToPay}");
            }
          
            var isSucceeded = _paymentService.Pay(payModel.CarPlate, payModel.Amount);
            if (!isSucceeded)
            {
                _logger.LogError($"Amount ot pay for car with plate: {payModel.CarPlate} is {amountToPay}");
                return BadRequest($"Amount ot pay for car with plate: {payModel.CarPlate} is {amountToPay}"); 
            }

            _logger.LogInformation($"Car with plate: {payModel.CarPlate} payed {payModel.Amount}");
            return Ok($"Car with plate: {payModel.CarPlate} payed {payModel.Amount}");
        }
    }
}