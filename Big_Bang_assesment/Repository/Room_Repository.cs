﻿
using Big_Bang_assesment.DB;
using Big_Bang_assesment.Models;
using Big_Bang_assesment.Repository;

namespace Big_Bang_assesment.Repository
{
    public class RoomRepository : IRoom
    {
        private readonly HotelContext Context;

        public RoomRepository(HotelContext con)
        {
            Context = con;
        }
        public Room GetRoomByid(int id)
        {
            return Context.Rooms.FirstOrDefault(x => x.Room_Id == id);
        }
        public IEnumerable<Room> GetRoom()
        {
            return Context.Rooms.ToList();
        }
        public Room PostRoom(Room rooms)
        {
            Context.Rooms.Find(rooms.Room_Id);
            Context.Rooms.Add(rooms);
            Context.SaveChanges();
            return rooms;
        }
        public void PutRoom(Room rooms)
        {
            Context.Entry(rooms).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
        public void DeleteRoom(int id)
        {
            Room e = Context.Rooms.FirstOrDefault(x => x.Room_Id == id);
            Context.Rooms.Remove(e);
            Context.SaveChanges();
        }
        public IEnumerable<Room> GetAmenities(string amenities)
        {
            return Context.Rooms.Where(e => e.Room_Amenities == amenities).ToList();
        }
        public IEnumerable<Room> GetPrice(int price)
        {
            return Context.Rooms.Where(e => e.Room_Price == price).ToList();
        }

    }
}
