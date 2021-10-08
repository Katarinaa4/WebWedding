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
    [Route("api/MuzikaRezervisani")]
    [ApiController]
    public class MuzikaRezervisaniController : Controller
    {

        private readonly IMuzikaRezervisaniService _muzikaRezervisaniService;

        public MuzikaRezervisaniController(IMuzikaRezervisaniService _mRS)
        {
            _muzikaRezervisaniService = _mRS;
        }

        // GET: api/MuzikaRezervisani
        [HttpGet]
        public IEnumerable<MuzikaRezervisani> Get()
        {
            return _muzikaRezervisaniService.ReadAll();
        }

        // GET: api/MuzikaRezervisani/5
        [HttpGet("get/{id}")]
        public MuzikaRezervisani Get(int id)
        {
            return _muzikaRezervisaniService.Read(id);
        }

        // POST: api/MuzikaRezervisani
        [HttpPost]
        public void Post([FromBody] MuzikaRezervisani pr)
        {
            _muzikaRezervisaniService.Create(pr);
        }

        // PUT: api/MuzikaRezervisani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MuzikaRezervisani mr)
        {
            _muzikaRezervisaniService.Update(mr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _muzikaRezervisaniService.Delete(id);
        }
    }
}
