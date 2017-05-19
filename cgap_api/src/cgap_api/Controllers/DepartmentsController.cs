using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cgap_api.Repository.Departments;
using cgap_api.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace cgap_api.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsRepository _departmentsRepo;

        public DepartmentsController(IDepartmentsRepository departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Department> GetAll()
        {
            return _departmentsRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDep")]
        public IActionResult GetById(int id)
        {
            var item = _departmentsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Department item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _departmentsRepo.Add(item);

            return CreatedAtRoute("GetDep", new { Controller = "Departments", id = item.DepartmentID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Department item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = _departmentsRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            _departmentsRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentsRepo.Remove(id);
        }
    }
}
