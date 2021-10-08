using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IDekoracijaZakazaniService
    {
        List<DekoracijaZakazani> ReadAll();
        void Create(DekoracijaZakazani dr);
        DekoracijaZakazani Read(int id);
        void Update(DekoracijaZakazani modifiedDR);
        void Delete(int id);
    }
    public class DekoracijaZakazaniService : IDekoracijaZakazaniService
    {
        private readonly WebWeddingContext _context;

        public DekoracijaZakazaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(DekoracijaZakazani dr)
        {
            _context.DekoracijaZakazaniD.Add(dr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            DekoracijaZakazani pr = _context.DekoracijaZakazaniD.Find(id);
            if (pr != null)
            {
                _context.DekoracijaZakazaniD.Remove(pr);
                _context.SaveChanges();
            }
        }

        public DekoracijaZakazani Read(int id)
        {
            DekoracijaZakazani pr = _context.DekoracijaZakazaniD.Include(x => x.MojaDekoracija).Where(x => x.Id == id).FirstOrDefault();
            if (pr != null)
            {
                return pr;
            }
            else return null;
        }

        public List<DekoracijaZakazani> ReadAll()
        {
            return _context.DekoracijaZakazaniD.Include(x => x.MojaDekoracija).ToList();
        }

        public void Update(DekoracijaZakazani modifiedDR)
        {
            DekoracijaZakazani dr = _context.DekoracijaZakazaniD.Find(modifiedDR.Id);
            if (dr != null)
            {
                dr.datum = modifiedDR.datum;
                dr.MojaDekoracija = modifiedDR.MojaDekoracija;
                _context.DekoracijaZakazaniD.Update(dr);
                _context.SaveChanges();
            }
        }
    }
}
