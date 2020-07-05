using System.ComponentModel.DataAnnotations;

namespace ParkingExpert.DB.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}