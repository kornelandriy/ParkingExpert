using System;

namespace ParkingExpert.Models.Models.Dtos
{
    public class ParkingPlace
    {
        public int PlaceNumber { get; set; }
        public string CarPlate { get; set; }
        public bool Payed { get; set; }
        public DateTime? ArrivedAt { get; set; }
        public DateTime? DepartureAt { get; set; }
        public bool IsAvailable { get; set; }
    }
}