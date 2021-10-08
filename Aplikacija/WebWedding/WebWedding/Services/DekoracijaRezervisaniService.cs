using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IDekoracijaRezervisaniService
    {
        List<DekoracijaRezervisani> ReadAll();
        void Create(DekoracijaRezervisani dr);
        DekoracijaRezervisani Read(int id);
        void Update(DekoracijaRezervisani modifiedDR);
        void Delete(int id);
    }
    public class DekoracijaRezervisaniService : IDekoracijaRezervisaniService
    {
        private readonly WebWeddingContext _context;

        public DekoracijaRezervisaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(DekoracijaRezervisani dr)
        {
            _context.DekoracijaRezervisaniD.Add(dr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            DekoracijaRezervisani pr = _context.DekoracijaRezervisaniD.Find(id);
            if (pr != null)
            {
                _context.DekoracijaRezervisaniD.Remove(pr);
                _context.SaveChanges();
            }
        }

        public DekoracijaRezervisani Read(int id)
        {
            DekoracijaRezervisani pr = _context.DekoracijaRezervisaniD.Include(x => x.MojaDekoracija).Where(x => x.Id == id).FirstOrDefault();
            if (pr != null)
            {
                return pr;
            }
            else return null;
        }

        public List<DekoracijaRezervisani> ReadAll()
        {
            return _context.DekoracijaRezervisaniD.Include(x => x.MojaDekoracija).ToList();
        }

        public void Update(DekoracijaRezervisani modifiedDR)
        {
            DekoracijaRezervisani dr = _context.DekoracijaRezervisaniD.Find(modifiedDR.Id);
            if (dr != null)
            {
                dr.datum = modifiedDR.datum;
                dr.MojaDekoracija = modifiedDR.MojaDekoracija;
                _context.DekoracijaRezervisaniD.Update(dr);
                _context.SaveChanges();
            }
        }
    }
}
