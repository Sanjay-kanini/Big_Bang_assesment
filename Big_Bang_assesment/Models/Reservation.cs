using System.ComponentModel.DataAnnotations;

namespace Big_Bang_assesment.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_Id { get; set; } 
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set;}

        public Room? Room { get; set; }
        public Guest? Guest { get; set; }
    }
}
