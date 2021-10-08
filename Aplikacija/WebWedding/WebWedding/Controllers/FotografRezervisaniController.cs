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
    [Route("api/FotografRezervisani")]
    [ApiController]
    public class FotografRezervisaniController : Controller
    {

        private readonly IFotografRezervisaniService _fotografRezervisaniService;

        public FotografRezervisaniController(IFotografRezervisaniService _fRS)
        {
            _fotografRezervisaniService = _fRS;
        }

        // GET: api/FotografRezervisani
        [HttpGet]
        public IEnumerable<FotografRezervisani> Get()
        {
            return _fotografRezervisaniService.ReadAll();
        }

        // GET: api/FotografRezervisani/5
        [HttpGet("get/{id}")]
        public FotografRezervisani Get(int id)
        {
            return _fotografRezervisaniService.Read(id);
        }

        // POST: api/FotografRezervisani
        [HttpPost]
        public void Post([FromBody] FotografRezervisani fr)
        {
            _fotografRezervisaniService.Create(fr);
        }

        // PUT: api/FotografRezervisani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FotografRezervisani fr)
        {
            _fotografRezervisaniService.Update(fr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fotografRezervisaniService.Delete(id);
        }
    }
}
