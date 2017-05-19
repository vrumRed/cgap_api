using cgap_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Repository.Users
{
    public interface IUsersRepository
    {
        void Add(User item);
        IEnumerable<User> GetAll();
        User Find(String key);
        void Remove(String Id);
        void Update(User itemToUpdate, User item);
    }
}
