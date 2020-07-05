using System;
using System.Linq;
using ParkingExpert.Services.Abstractions;
using Microsoft.Extensions.Logging;
using ParkingExpert.DB.Entities;
using ParkingExpert.Repositories.Abstractions;

namespace ParkingExpert.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly IRepository<Settings> _settings;
        private readonly IParkingService _parkingService;
        private readonly IRepository<ParkingPlace> _parkingPlaces;

        public PaymentService(ILogger<PaymentService> logger, 
            IRepository<Settings> settings, 
            IParkingService parkingService,
            IRepository<ParkingPlace> parkingPlaces)
        {
            _logger = logger;
            _settings = settings;
            _parkingService = parkingService;
            _parkingPlaces = parkingPlaces;
        }

        public decimal GetAmountToPayByCarPlate(string carPlate)
        {
            var parkingPlace = _parkingService.GetParkingPlaceByCarPlate(carPlate);
            if (parkingPlace == null)
            {
                _logger.LogError($"Car with plate: {carPlate} is not in the parking");
                throw new ArgumentNullException($"Car with plate: {carPlate} is not in the parking");
            }

            if (parkingPlace.PayedAt.HasValue && parkingPlace.PayedAt.Value.AddMinutes(15) < DateTime.Now) return 0;

            var price = _settings.GetAll().Single().PricePerHour;
            var time = (DateTime.Now - parkingPlace.ArrivedAt).Hours + 1;
            return (time * price) - parkingPlace.PayedAmount;
        }

        public (bool canExit, decimal amountToPay) IsAllowToExit(string carPlate)
        {
            var parkingPlace = _parkingService.GetParkingPlaceByCarPlate(carPlate);
            if (parkingPlace == null)
            {
                _logger.LogError($"Car with plate: {carPlate} is not in the parking");
                throw new ArgumentNullException($"Car with plate: {carPlate} is not in the parking");
            }

            if (!parkingPlace.PayedAt.HasValue || parkingPlace.PayedAt.Value.AddMinutes(15) < DateTime.Now)
            {
                parkingPlace.PayedAt = null;
                _parkingPlaces.Update(parkingPlace);
                _logger.LogError($"Parking is not payed for car with plate: {carPlate}");
                return (false, GetAmountToPayByCarPlate(carPlate));
            }

            return (true, 0);
        }

        public bool Pay(string carPlate, decimal amount)
        {
            var parkingPlace = _parkingService.GetParkingPlaceByCarPlate(carPlate);
            if (parkingPlace == null)
            {
                _logger.LogError($"Car with plate: {carPlate} is not in the parking");
                throw new ArgumentNullException($"Car with plate: {carPlate} is not in the parking");
            }

            if (parkingPlace.PayedAt.HasValue)
            {
                return false;
            }
            
            parkingPlace.PayedAt = DateTime.Now;
            parkingPlace.PayedAmount += amount;
            _parkingPlaces.Update(parkingPlace);
            return true;
        }
    }
}