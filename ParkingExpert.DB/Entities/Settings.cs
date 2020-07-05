using System.ComponentModel.DataAnnotations;

namespace ParkingExpert.DB.Entities
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public decimal PricePerHour { get; set; }
    }
}