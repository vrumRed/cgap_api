using cgap_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Repository.Products
{
    public interface IProductsRepository
    {
        void Add(Product item);
        IEnumerable<Product> GetAll();
        Product Find(int key);
        void Remove(int Id);
        void Update(Product itemToUpdate, Product item);
    }
}
