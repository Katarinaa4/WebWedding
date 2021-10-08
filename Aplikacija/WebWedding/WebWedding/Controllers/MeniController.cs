using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWedding.Services;
using WebWedding.Models;

namespace WebWedding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniController : Controller
    {
        private readonly IMeniService _meniService;

        public MeniController(IMeniService ims)
        {
            _meniService = ims;
        }

        // GET: api/Meni
        [HttpGet]
        public IEnumerable<Meni> Get()
        {
            return _meniService.ReadAll();
        }

        // GET: api/Meni/5
        [HttpGet("{id}")]
        public Meni Get(int id)
        {
            return _meniService.Read(id);
        }

        // POST: api/Meni
        [HttpPost]
        public void Post([FromBody] Meni meni)
        {
            _meniService.Create(meni);
        }

        // PUT: api/Meni/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Meni meni)
        {
            _meniService.Update(meni);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _meniService.Delete(id);
        }
    }
}
