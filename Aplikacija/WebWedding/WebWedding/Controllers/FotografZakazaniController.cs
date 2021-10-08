using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebWedding.Models;
using WebWedding.Services;

namespace WebWedding.Controllers
{
    [Produces("application/json")]
    [Route("api/FotografZakazani")]
    [ApiController]
    public class FotografZakazaniController : Controller
    {

        private readonly IFotografZakazaniService _fotografZakazaniService;

        public FotografZakazaniController(IFotografZakazaniService _fRS)
        {
            _fotografZakazaniService = _fRS;
        }

        // GET: api/FotografZakazani
        [HttpGet]
        public IEnumerable<FotografZakazani> Get()
        {
            return _fotografZakazaniService.ReadAll();
        }

        // GET: api/FotografZakazani/5
        [HttpGet("get/{id}")]
        public FotografZakazani Get(int id)
        {
            return _fotografZakazaniService.Read(id);
        }

        // POST: api/FotografZakazani
        [HttpPost]
        public void Post([FromBody] FotografZakazani fr)
        {
            _fotografZakazaniService.Create(fr);
        }

        // PUT: api/FotografZakazani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FotografZakazani fr)
        {
            _fotografZakazaniService.Update(fr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fotografZakazaniService.Delete(id);
        }
    }
}
