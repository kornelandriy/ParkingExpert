namespace ParkingExpert.DB.Entities
{
    public class Settings : BaseEntity
    {
        public decimal PricePerHour { get; set; }
        public int ParkingCapacity { get; set; }
    }
}