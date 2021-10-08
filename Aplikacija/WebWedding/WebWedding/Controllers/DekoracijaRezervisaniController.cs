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
    [Route("api/DekoracijaRezervisani")]
    [ApiController]
    public class DekoracijaRezervisaniController : Controller
    {

        private readonly IDekoracijaRezervisaniService _dekoracijaRezervisaniService;

        public DekoracijaRezervisaniController(IDekoracijaRezervisaniService _dRS)
        {
            _dekoracijaRezervisaniService = _dRS;
        }

        // GET: api/DekoracijaRezervisani
        [HttpGet]
        public IEnumerable<DekoracijaRezervisani> Get()
        {
            return _dekoracijaRezervisaniService.ReadAll();
        }

        // GET: api/DekoracijaRezervisani/5
        [HttpGet("get/{id}")]
        public DekoracijaRezervisani Get(int id)
        {
            return _dekoracijaRezervisaniService.Read(id);
        }

        // POST: api/DekoracijaRezervisani
        [HttpPost]
        public void Post([FromBody] DekoracijaRezervisani dr)
        {
            _dekoracijaRezervisaniService.Create(dr);
        }

        // PUT: api/DekoracijaRezervisani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DekoracijaRezervisani dr)
        {
            _dekoracijaRezervisaniService.Update(dr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dekoracijaRezervisaniService.Delete(id);
        }
    }
}
