namespace ParkingExpert.Services.Abstractions
{
    public interface IPaymentService
    {
        decimal GetAmountToPayByCarPlate(string carPlate);
        (bool canExit, decimal amountToPay) IsAllowToExit(string carPlate);
        bool Pay(string carPlate, decimal amount);
    }
}