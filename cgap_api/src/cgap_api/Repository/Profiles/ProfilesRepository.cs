using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgap_api.Models;
using cgap_api.Data;

namespace cgap_api.Repository.Profiles
{
    public class ProfilesRepository : IProfilesRepository
    {
        public ApplicationDbContext context;

        public ProfilesRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Profile item)
        {
            context.Profiles.Add(item);
            context.SaveChanges();
        }

        public Profile Find(int key)
        {
            var item = context.Profiles.SingleOrDefault(p => p.ProfileID == key);
            return item;
        }

        public IEnumerable<Profile> GetAll()
        {
            return context.Profiles.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Profiles.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Profile itemToUpdate, Profile item)
        {
            itemToUpdate.Audit = item.Audit;
            itemToUpdate.Send = item.Send;
            itemToUpdate.Name = item.Name;
            itemToUpdate.Receive = item.Receive;
            itemToUpdate.Users = item.Users;
            context.Profiles.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
