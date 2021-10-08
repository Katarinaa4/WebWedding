using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IProstorZakazaniService
    {
        List<ProstorZakazani> ReadAll();
        void Create(ProstorZakazani pr);
        ProstorZakazani Read(int id);
        void Update(ProstorZakazani modifiedPR);
        void Delete(int id);
    }
    public class ProstorZakazaniService : IProstorZakazaniService
    {
        private readonly WebWeddingContext _context;

        public ProstorZakazaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(ProstorZakazani pr)
        {
            _context.ZakazaniDatumi.Add(pr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProstorZakazani pr = _context.ZakazaniDatumi.Find(id);
            if (pr != null)
            {
                _context.ZakazaniDatumi.Remove(pr);
                _context.SaveChanges();
            }
        }

        public ProstorZakazani Read(int id)
        {
            //IList<ProstorZakazani> list = _context.ZakazaniDatumi.Include(x => x.MojProstor).ToList();
            //ProstorZakazani pr = list.FirstOrDefault(x => x.Id == id);
            ProstorZakazani pr = _context.ZakazaniDatumi.Include(x => x.MojProstor).Where(x => x.Id == id).FirstOrDefault();
            if (pr != null)
            {
                return pr;
            }
            else return null;
        }

        public List<ProstorZakazani> ReadAll()
        {
            return _context.ZakazaniDatumi.Include(x => x.MojProstor).ToList();
        }

        public void Update(ProstorZakazani modifiedPR)
        {
            ProstorZakazani pr = _context.ZakazaniDatumi.Find(modifiedPR.Id);
            if (pr != null)
            {
                pr.datum = modifiedPR.datum;
                pr.MojProstor = modifiedPR.MojProstor;
                _context.ZakazaniDatumi.Update(pr);
                _context.SaveChanges();
            }
        }
    }
}
