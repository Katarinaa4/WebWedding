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
    [Route("api/ProstorRezervisani")]
    [ApiController]
    public class ProstorRezervisaniController : Controller
    {

        private readonly IProstorRezervisaniService _prostorRezervisaniService;

        public ProstorRezervisaniController(IProstorRezervisaniService _pRS)
        {
            _prostorRezervisaniService = _pRS;
        }

        // GET: api/ProstorRezervisani
        [HttpGet]
        public IEnumerable<ProstorRezervisani> Get()
        {
            return _prostorRezervisaniService.ReadAll();
        }

        // GET: api/ProstorRezervisani/5
        [HttpGet("get/{id}")]
        public ProstorRezervisani Get(int id)
        {
            return _prostorRezervisaniService.Read(id);
        }

        // POST: api/ProstorRezervisani
        [HttpPost]
        public void Post([FromBody] ProstorRezervisani pr)
        {
            _prostorRezervisaniService.Create(pr);
        }

        // PUT: api/ProstorRezervisani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProstorRezervisani pr)
        {
            _prostorRezervisaniService.Update(pr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _prostorRezervisaniService.Delete(id);
        }
    }
}
