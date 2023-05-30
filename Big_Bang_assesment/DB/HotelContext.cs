using Big_Bang_assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang_assesment.DB
{
    using Microsoft.EntityFrameworkCore;

    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
         public DbSet<Reservation> Reservations { get; set; }   

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        // DbSet properties and other configurations
    }

}
