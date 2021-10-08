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
    [Route("api/MuzikaZakazani")]
    [ApiController]
    public class MuzikaZakazaniController : Controller
    {

        private readonly IMuzikaZakazaniService _muzikaZakazaniService;

        public MuzikaZakazaniController(IMuzikaZakazaniService _mRS)
        {
            _muzikaZakazaniService = _mRS;
        }

        // GET: api/MuzikaZakazani
        [HttpGet]
        public IEnumerable<MuzikaZakazani> Get()
        {
            return _muzikaZakazaniService.ReadAll();
        }

        // GET: api/MuzikaZakazani/5
        [HttpGet("get/{id}")]
        public MuzikaZakazani Get(int id)
        {
            return _muzikaZakazaniService.Read(id);
        }

        // POST: api/MuzikaZakazani
        [HttpPost]
        public void Post([FromBody] MuzikaZakazani pr)
        {
            _muzikaZakazaniService.Create(pr);
        }

        // PUT: api/MuzikaZakazani/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MuzikaZakazani mr)
        {
            _muzikaZakazaniService.Update(mr);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _muzikaZakazaniService.Delete(id);
        }
    }
}
