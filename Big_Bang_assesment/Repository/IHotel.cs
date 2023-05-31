using Big_Bang_assesment.Models;

namespace Big_Bang_assesment.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetHotel();
        public Hotel GetHotelByid(int id);
        public Hotel PostHotel(Hotel hotel);

        public void PutHotel(Hotel hotel);

        public void DeleteHotel(int id);

        IEnumerable<Hotel> GetLocation(string location);

       
    }
}
