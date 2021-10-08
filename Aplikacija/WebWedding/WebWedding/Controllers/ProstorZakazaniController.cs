using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWedding.Models;
using WebWedding.Services;

namespace WebWedding.Controllers
{
    [Produces("application/json")]
    [Route("api/ProstorZakazani")]
    [ApiController]
    public class ProstorZakazaniController : Controller
    {
        private readonly IProstorZakazaniService _service;


        public ProstorZakazaniController(IProstorZakazaniService service)
        {
            _service = service;
        }

        // GET: api/ProstorZakazani
        [HttpGet]
        public IEnumerable<ProstorZakazani> Get()
        {
            return _service.ReadAll();
        }

        // GET: api/ProstorZakazani/get/5
        [HttpGet("get/{id}")]
        public ProstorZakazani Get(int id)
        {
            return _service.Read(id);
        }

        // POST: api/ProstorZakazani
        [HttpPost]
        public void Post([FromBody] ProstorZakazani pr)
        {
            _service.Create(pr);
        }

        // PUT: api/ProstorZakazani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProstorZakazani pr)
        {
            _service.Update(pr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
