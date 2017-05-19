using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgap_api.Models;
using cgap_api.Data;

namespace cgap_api.Repository.Products
{
    public class ProductsRepository : IProductsRepository
    {
        ApplicationDbContext context;

        public ProductsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
        }

        public Product Find(int key)
        {
            var item = context.Products.SingleOrDefault(p => p.ProductID == key);
            return item;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Product itemToUpdate, Product item)
        {
            itemToUpdate.Brand = item.Brand;
            itemToUpdate.Tag = item.Tag;
            itemToUpdate.Description = item.Description;
            itemToUpdate.Price = item.Price;
            itemToUpdate.Room = item.Room;
            itemToUpdate.RoomID = item.RoomID;
            context.Products.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
