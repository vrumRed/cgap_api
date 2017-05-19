using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cgap_api.Repository.Products;
using cgap_api.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace cgap_api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IProductsRepository ProductsRepo { get; set; }

        public ProductsController(IProductsRepository _ProductsRepo)
        {
            ProductsRepo = _ProductsRepo;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return ProductsRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public IActionResult GetById(int id)
        {
            var item = ProductsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ProductsRepo.Add(item);
            return CreatedAtRoute("GetProducts", new { Controller = "Products", id = item.ProductID }, item);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = ProductsRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            ProductsRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            ProductsRepo.Remove(id);
        }
    }
}
