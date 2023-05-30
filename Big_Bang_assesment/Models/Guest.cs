using System.ComponentModel.DataAnnotations;

namespace Big_Bang_assesment.Models
{
    public class Guest
    {
        [Key]
        public int Guest_Id { get; set; }   
        public string? Guest_Name { get; set; }
        public string? Guest_email { get; set; }
        public string? Guest_pwd { get; set; }  

        public ICollection<Reservation> Reservations { get; set; }  
    }
}
