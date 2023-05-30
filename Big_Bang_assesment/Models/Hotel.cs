
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Big_Bang_assesment.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_id { get; set; }
        public string? Hotel_name { get; set; }
        public string? Hotel_Location { get; set; }
        public int Hotel_rating { get; set; }
         public int Hotel_Phone { get; set; }

        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Guest>? Guests { get; set;}

    }
}
