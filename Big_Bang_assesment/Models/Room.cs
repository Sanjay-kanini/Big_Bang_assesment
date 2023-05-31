using System.ComponentModel.DataAnnotations;

namespace Big_Bang_assesment.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        public string? Room_type { get; set; }
        public int Room_Price { get; set; }
        public string? Room_Amenities { get; set; } 
        
        public int Room_availability { get; set; }  

        public Hotel? Hotel { get; set; }
    }
}
