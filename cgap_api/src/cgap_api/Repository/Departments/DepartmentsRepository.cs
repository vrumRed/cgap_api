using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgap_api.Models;
using cgap_api.Data;

namespace cgap_api.Repository.Departments
{
    public class DepartmentsRepository : IDepartmentsRepository
    {

        ApplicationDbContext context;

        public DepartmentsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Department item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public Department Find(int key)
        {
            var item = context.Departments.SingleOrDefault(d => d.DepartamentoID == id);
            return item;
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Departments.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Department itemToUpdate, Department item)
        {
            itemToUpdate.Name = item.Name;
            itemToUpdate.Country = item.Country;
            itemToUpdate.State = item.State;
            itemToUpdate.City = item.City;
            itemToUpdate.Rooms = item.Rooms;
            itemToUpdate.Users = item.Users;
            context.Departments.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
