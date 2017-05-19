using cgap_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Repository.Departments
{
    interface IDepartmentsRepository
    {
        void Add(Department item);
        IEnumerable<Department> GetAll();
        Deparament Find(int key);
        void Remove(int Id);
        void Update(Department itemToUpdate, Department item);
    }
}
