using ParkingExpert.DB.Entities;

namespace ParkingExpert.Services.Abstractions
{
    public interface IParkingService
    {
        ParkingPlace GetParkingPlaceByCarPlate(string carPlate);
        bool IsInParking(string carPlate);
        void AddToParking(string carPlate);
        void Exit(string carPlate);
    }
}