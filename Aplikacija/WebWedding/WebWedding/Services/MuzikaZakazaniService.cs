using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IMuzikaZakazaniService
    {
        List<MuzikaZakazani> ReadAll();
        void Create(MuzikaZakazani mr);
        MuzikaZakazani Read(int id);
        void Update(MuzikaZakazani modifiedMR);
        void Delete(int id);
    }
    public class MuzikaZakazaniService : IMuzikaZakazaniService
    {
        private readonly WebWeddingContext _context;

        public MuzikaZakazaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(MuzikaZakazani mr)
        {
            _context.MuzikaZakazaniD.Add(mr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            MuzikaZakazani mr = _context.MuzikaZakazaniD.Find(id);
            if (mr != null)
            {
                _context.MuzikaZakazaniD.Remove(mr);
                _context.SaveChanges();
            }
        }

        public MuzikaZakazani Read(int id)
        {
            MuzikaZakazani mr = _context.MuzikaZakazaniD.Include(x => x.MojaMuzika).Where(x => x.Id == id).FirstOrDefault();
            if (mr != null)
            {
                return mr;
            }
            else return null;
        }

        public List<MuzikaZakazani> ReadAll()
        {
            return _context.MuzikaZakazaniD.Include(x => x.MojaMuzika).ToList();
        }

        public void Update(MuzikaZakazani modifiedMR)
        {
            MuzikaZakazani mr = _context.MuzikaZakazaniD.Find(modifiedMR.Id);
            if (mr != null)
            {
                mr.datum = modifiedMR.datum;
                mr.MojaMuzika = modifiedMR.MojaMuzika;
                _context.MuzikaZakazaniD.Update(mr);
                _context.SaveChanges();
            }
        }
    }
}
