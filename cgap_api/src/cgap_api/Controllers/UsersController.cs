using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cgap_api.Repository.Users;
using cgap_api.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace cgap_api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public IUsersRepository UsersRepo { get; set; }

        public UsersController(IUsersRepository _UsersRepo)
        {
            UsersRepo = _UsersRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return UsersRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUsuarios")]
        public IActionResult GetById(String id)
        {
            var item = UsersRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            UsersRepo.Add(item);
            return CreatedAtRoute("GetUsuarios", new { Controller = "Usuarios", id = item.Id }, item);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(String id, [FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = UsersRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            UsersRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public void Delete(String id)
        {
            UsersRepo.Remove(id);
        }
    }
}
