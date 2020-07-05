using System;
using System.Linq;
using ParkingExpert.Services.Abstractions;
using Microsoft.Extensions.Logging;
using ParkingExpert.DB.Entities;
using ParkingExpert.Repositories.Abstractions;

namespace ParkingExpert.Services.Implementations
{
    public class ParkingService : IParkingService
    {
        private readonly ILogger<ParkingService> _logger;
        private readonly IRepository<ParkingPlace> _parkingPlaces;

        public ParkingService(ILogger<ParkingService> logger, 
            IRepository<ParkingPlace> parkingPlaces)
        {
            _logger = logger;
            _parkingPlaces = parkingPlaces;
        }

        public ParkingPlace GetParkingPlaceByCarPlate(string carPlate)
        {
            return _parkingPlaces.GetAll().FirstOrDefault(x => x.CarPlate == carPlate && !x.DepartureAt.HasValue);
        }

        public bool IsInParking(string carPlate)
        {
            return _parkingPlaces.GetAll().Any(x => x.CarPlate == carPlate && !x.DepartureAt.HasValue);
        }

        public void AddToParking(string carPlate)
        {
            var parkingPlace = new ParkingPlace
            {
                ArrivedAt = DateTime.Now, 
                CarPlate = carPlate
            };
            _parkingPlaces.Insert(parkingPlace);
        }

        public void Exit(string carPlate)
        {
            var parkingPlace = GetParkingPlaceByCarPlate(carPlate);
            if (parkingPlace == null)
            {
                _logger.LogError($"Car with plate: {carPlate} is not in the parking");
                throw new ArgumentNullException($"Car with plate: {carPlate} is not in the parking");
            }
            parkingPlace.DepartureAt = DateTime.Now;
            _parkingPlaces.Update(parkingPlace);
        }
    }
}