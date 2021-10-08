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
    [Route("api/DekoracijaZakazani")]
    [ApiController]
    public class DekoracijaZakazaniController : Controller
    {

        private readonly IDekoracijaZakazaniService _dekoracijaZakazaniService;

        public DekoracijaZakazaniController(IDekoracijaZakazaniService _dRS)
        {
            _dekoracijaZakazaniService = _dRS;
        }

        // GET: api/DekoracijaZakazani
        [HttpGet]
        public IEnumerable<DekoracijaZakazani> Get()
        {
            return _dekoracijaZakazaniService.ReadAll();
        }

        // GET: api/DekoracijaZakazani/5
        [HttpGet("get/{id}")]
        public DekoracijaZakazani Get(int id)
        {
            return _dekoracijaZakazaniService.Read(id);
        }

        // POST: api/DekoracijaZakazani
        [HttpPost]
        public void Post([FromBody] DekoracijaZakazani dr)
        {
            _dekoracijaZakazaniService.Create(dr);
        }

        // PUT: api/DekoracijaZakazani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DekoracijaZakazani dr)
        {
            _dekoracijaZakazaniService.Update(dr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dekoracijaZakazaniService.Delete(id);
        }
    }
}
