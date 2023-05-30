
using Big_Bang_assesment.Models;

namespace APIcodefirst.Repository
{
    public interface IRoom
    {
        public IEnumerable<Room> GetRoom();

        public Room GetRoomByid(int id);
        public Room PostRoom(Room rooms);

        public void PutRoom(Room rooms);

        public void DeleteRoom(int id);

    }
}
