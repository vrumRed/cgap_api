using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgap_api.Models;
using cgap_api.Data;

namespace cgap_api.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        public ApplicationDbContext context;

        public UsersRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
        }

        public User Find(String key)
        {
            var item = context.Users.SingleOrDefault(u => u.Id == key);
            return item;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Remove(String Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(User itemToUpdate, User item)
        {
            itemToUpdate.Rg = item.Rg;
            itemToUpdate.Cpf = item.Cpf;
            itemToUpdate.Birthdate = item.Birthdate;
            itemToUpdate.Email = item.Email;
            itemToUpdate.Department = item.Department;
            itemToUpdate.DepartmentID = item.DepartmentID;
            itemToUpdate.Name = item.Name;
            itemToUpdate.Profile = item.Profile;
            itemToUpdate.ProfileID = item.ProfileID;
            itemToUpdate.PhoneNumber = item.PhoneNumber;
            itemToUpdate.PictureLocale = item.PictureLocale;
            context.Users.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
