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
        private readonly IUsersRepository _usersRepo;

        public UsersController(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _usersRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUsuarios")]
        public IActionResult GetById(String id)
        {
            var item = _usersRepo.Find(id);
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
            _usersRepo.Add(item);
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
            var itemToUpdate = _usersRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            _usersRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public void Delete(String id)
        {
            _usersRepo.Remove(id);
        }
    }
}
