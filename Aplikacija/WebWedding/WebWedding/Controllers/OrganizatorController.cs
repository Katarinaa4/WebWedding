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
    public class OrganizatorController : Controller
    {

        private readonly IOrganizatorService _organizatorService;

        public OrganizatorController(IOrganizatorService ios)
        {
            _organizatorService = ios;
        }
        // GET: api/Organizator
        [HttpGet]
        public IEnumerable<Organizator> Get()
        {
            return _organizatorService.ReadAll();
        }

        // GET: api/Organizator/5
        [HttpGet("{id}")]
        public Organizator Get(int id)
        {
            return _organizatorService.Read(id);
        }

        // POST: api/Organizator
        [HttpPost]
        public void Post([FromBody] Organizator org)
        {
            _organizatorService.Create(org);
        }

        // PUT: api/Organizator/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Organizator modifiedO)
        {
            _organizatorService.Update(modifiedO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _organizatorService.Delete(id);
        }
    }
}
