using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cgap_api.Repository.Rooms;
using cgap_api.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace cgap_api.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        public IRoomsRepository RoomRepo { get; set; }

        public RoomsController(IRoomsRepository _RoomRepo)
        {
            RoomRepo = _RoomRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Room> GetAll()
        {
            return RoomRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRooms")]
        public IActionResult Get(int id)
        {
            var item = RoomRepo.Find(id);

            if (item == null)
                return BadRequest();

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Room item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            RoomRepo.Add(item);

            return CreatedAtRoute("GetRooms", new { controller = "Rooms", id = item.RoomID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Room item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = RoomRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            RoomRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public void Delete(int id)
        {
            RoomRepo.Remove(id);
        }
    }
}
