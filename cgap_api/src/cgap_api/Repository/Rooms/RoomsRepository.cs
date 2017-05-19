using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgap_api.Models;
using cgap_api.Data;

namespace cgap_api.Repository.Rooms
{
    public class RoomsRepository : IRoomsRepository
    {
        ApplicationDbContext context;

        public RoomsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Room item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public Room Find(int key)
        {
            var item = context.Rooms.SingleOrDefault(s => s.SalaID == id);
            return item;
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Rooms.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Room itemToUpdate, Room item)
        {
            itemToUpdate.Name = item.Name;
            itemToUpdate.Products = item.Products;
            itemToUpdate.Tag = item.Tag;
            itemToUpdate.DepartmentID = item.DepartmentID;
            itemToUpdate.Department = item.Department;
            context.Rooms.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
