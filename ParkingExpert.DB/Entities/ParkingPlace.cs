using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingExpert.DB.Entities
{
    public class ParkingPlace
    {
        [Key]
        public int Id { get; set; }
        public string CarPlate { get; set; }
        public bool Payed { get; set; }
        public DateTime? ArrivedAt { get; set; }
        public DateTime? DepartureAt { get; set; }
        public bool IsAvailable { get; set; }
    }
}