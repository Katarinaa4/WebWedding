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
    public class KorisnikController : Controller
    {
        private readonly IKorisnikService _korisnikService;

        public KorisnikController(IKorisnikService iks)
        {
            _korisnikService = iks;
        }

        // GET: api/Korisnik
        [HttpGet]
        public IEnumerable<Korisnik> Get()
        {
            return _korisnikService.ReadAll();
        }

        // GET: api/Korisnik/5
        [HttpGet("{id}")]
        public Korisnik Get(int id)
        {
            return _korisnikService.Read(id);
        }

        // POST: api/Korisnik
        [HttpPost]
        public void Post([FromBody] Korisnik k)
        {
            _korisnikService.Create(k);
        }

        // PUT: api/Korisnik/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Korisnik k)
        {
            _korisnikService.Update(k);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _korisnikService.Delete(id);
        }
    }
}
