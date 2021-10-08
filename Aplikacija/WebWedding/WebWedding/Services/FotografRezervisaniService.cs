using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IFotografRezervisaniService
    {
        List<FotografRezervisani> ReadAll();
        void Create(FotografRezervisani fr);
        FotografRezervisani Read(int id);
        void Update(FotografRezervisani modifiedFR);
        void Delete(int id);
    }
    public class FotografRezervisaniService : IFotografRezervisaniService
    {
        private readonly WebWeddingContext _context;

        public FotografRezervisaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(FotografRezervisani fr)
        {
            _context.FotografiRezervisaniD.Add(fr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            FotografRezervisani fr = _context.FotografiRezervisaniD.Find(id);
            if (fr != null)
            {
                _context.FotografiRezervisaniD.Remove(fr);
                _context.SaveChanges();
            }
        }

        public FotografRezervisani Read(int id)
        {
            FotografRezervisani fr = _context.FotografiRezervisaniD.Include(x => x.MojFotograf).Where(x => x.Id == id).FirstOrDefault();
            if (fr != null)
            {
                return fr;
            }
            else return null;
        }

        public List<FotografRezervisani> ReadAll()
        {
            return _context.FotografiRezervisaniD.Include(x => x.MojFotograf).ToList();
        }

        public void Update(FotografRezervisani modifiedFR)
        {
            FotografRezervisani fr = _context.FotografiRezervisaniD.Find(modifiedFR.Id);
            if (fr != null)
            {
                fr.datum = modifiedFR.datum;
                fr.MojFotograf = modifiedFR.MojFotograf;
                _context.FotografiRezervisaniD.Update(fr);
                _context.SaveChanges();
            }
        }
    }
}
