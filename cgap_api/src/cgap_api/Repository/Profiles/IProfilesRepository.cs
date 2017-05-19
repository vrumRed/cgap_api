using cgap_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Repository.Profiles
{
    public interface IProfilesRepository
    {
        void Add(Profile item);
        IEnumerable<Profile> GetAll();
        Profile Find(int key);
        void Remove(int Id);
        void Update(Profile itemToUpdate, Profile item);
    }
}
