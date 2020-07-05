using System;

namespace ParkingExpert.DB.Entities
{
    public class ParkingPlace : BaseEntity
    {
        public string CarPlate { get; set; }
        public bool Payed { get; set; }
        public DateTime? ArrivedAt { get; set; }
        public DateTime? DepartureAt { get; set; }
    }
}