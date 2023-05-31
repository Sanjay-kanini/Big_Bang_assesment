using Big_Bang_assesment.DB;
using Big_Bang_assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang_assesment.Repository
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext Context;

        public HotelRepository(HotelContext con)
        {
            Context = con;
        }
        public Hotel GetHotelByid(int id)

        {

            return Context.Hotels.FirstOrDefault(x => x.Hotel_id == id);
        }
        public IEnumerable<Hotel> GetHotel()
        {
            return Context.Hotels
                .Include(x => x.Rooms)
                .ToList();
        }
        public Hotel PostHotel(Hotel hotel)
        {
            Context.Hotels.Find(hotel.Hotel_id);
            Context.Hotels.Add(hotel);
            Context.SaveChanges();
            return hotel;
        }
        public void PutHotel(Hotel hotel)
        {
            Context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
        public void DeleteHotel(int id)
        {
            Hotel e = Context.Hotels.FirstOrDefault(x => x.Hotel_id == id);
            Context.Hotels.Remove(e);
            Context.SaveChanges();
        }
        public IEnumerable<Hotel> GetLocation(string location)
        {
            return Context.Hotels.Where(e => e.Hotel_Location == location).ToList();
        }


      

        /*public int GetRoomAvailabilityCount(string hotelname)
        {
            var hotel = Context.Hotels.Include(f => f.Rooms).FirstOrDefault(f => f.Hotel_name == hotelname);
            if (hotel == null)
                return 0;

            int totalrooms = hotel.RoomAvailability;
            int bookedrooms = hotel.Reservations.Count();
            int availablerooms = totalrooms - bookedrooms;

            return availablerooms >= 0 ? availablerooms : 0;
        }*/
    }
}
