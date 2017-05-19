using cgap_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Repository.Rooms
{
    interface IRoomsRepository
    {
        void Add(Room item);
        IEnumerable<Room> GetAll();
        Room Find(int key);
        void Remove(int Id);
        void Update(Room itemToUpdate, Room item);
    }
}
