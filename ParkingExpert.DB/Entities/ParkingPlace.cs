using System;

namespace ParkingExpert.DB.Entities
{
    public class ParkingPlace : BaseEntity
    {
        public string CarPlate { get; set; }
        public DateTime? PayedAt { get; set; }
        public DateTime ArrivedAt { get; set; }
        public DateTime? DepartureAt { get; set; }
        public decimal PayedAmount { get; set; }
    }
}