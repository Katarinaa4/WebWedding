using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IFotografZakazaniService
    {
        List<FotografZakazani> ReadAll();
        void Create(FotografZakazani fr);
        FotografZakazani Read(int id);
        void Update(FotografZakazani modifiedFR);
        void Delete(int id);
    }
    public class FotografZakazaniService : IFotografZakazaniService
    {
        private readonly WebWeddingContext _context;

        public FotografZakazaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(FotografZakazani fr)
        {
            _context.FotografiZakazaniD.Add(fr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            FotografZakazani fr = _context.FotografiZakazaniD.Find(id);
            if (fr != null)
            {
                _context.FotografiZakazaniD.Remove(fr);
                _context.SaveChanges();
            }
        }

        public FotografZakazani Read(int id)
        {
            FotografZakazani fr = _context.FotografiZakazaniD.Include(x => x.MojFotograf).Where(x => x.Id == id).FirstOrDefault();
            if (fr != null)
            {
                return fr;
            }
            else return null;
        }

        public List<FotografZakazani> ReadAll()
        {
            return _context.FotografiZakazaniD.Include(x => x.MojFotograf).ToList();
        }

        public void Update(FotografZakazani modifiedFR)
        {
            FotografZakazani fr = _context.FotografiZakazaniD.Find(modifiedFR.Id);
            if (fr != null)
            {
                fr.datum = modifiedFR.datum;
                fr.MojFotograf = modifiedFR.MojFotograf;
                _context.FotografiZakazaniD.Update(fr);
                _context.SaveChanges();
            }
        }
    }
}
