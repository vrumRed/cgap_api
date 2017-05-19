using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cgap_api.Repository.Profiles;
using cgap_api.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace cgap_api.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        public IProfilesRepository ProfilesRepo { get; set; }

        public ProfilesController(IProfilesRepository _ProfilesRepo)
        {
            ProfilesRepo = _ProfilesRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Profile> GetAll()
        {
            return ProfilesRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetProfiles")]
        public IActionResult GetById(int id)
        {
            var item = ProfilesRepo.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Profile item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            ProfilesRepo.Add(item);

            return CreatedAtRoute("GetProfiles", new { Controller = "Profiles", id = item.ProfileID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Profile item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = ProfilesRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            ProfilesRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProfilesRepo.Remove(id);
        }
    }
}
