using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWedding.Services;

namespace WebWedding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService ias)
        {
            _adminService = ias;
        }

        // GET: api/Admin
        [HttpGet]
        public IEnumerable<Administrator> Get()
        {
            return _adminService.ReadAll();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public Administrator Get(int id)
        {
            return _adminService.Read(id);
        }

        // POST: api/Admin
        [HttpPost]
        public void Post([FromBody] Administrator a)
        {
            _adminService.Create(a);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Administrator a)
        {
            _adminService.Update(a);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _adminService.Delete(id);
        }
    }
}
