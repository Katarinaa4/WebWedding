using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IProstorRezervisaniService
    {
        List<ProstorRezervisani> ReadAll();
        void Create(ProstorRezervisani pr);
        ProstorRezervisani Read(int id);
        void Update(ProstorRezervisani modifiedPR);
        void Delete(int id);
    }
    public class ProstorRezervisaniService : IProstorRezervisaniService
    {
        private readonly WebWeddingContext _context;
        
        public ProstorRezervisaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(ProstorRezervisani pr)
        {
            _context.RezervisaniDatumi.Add(pr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProstorRezervisani pr = _context.RezervisaniDatumi.Find(id);
            if(pr!=null)
            {
                _context.RezervisaniDatumi.Remove(pr);
                _context.SaveChanges();
            }
        }

        public ProstorRezervisani Read(int id)
        {
            //IList<ProstorRezervisani> list = _context.RezervisaniDatumi.Include(x => x.MojProstor).ToList();
            // ProstorRezervisani pr = list.FirstOrDefault(x => x.Id == id);
            ProstorRezervisani pr = _context.RezervisaniDatumi.Include(x => x.MojProstor).Where(x => x.Id == id).FirstOrDefault();
            if (pr != null)
            {
                return pr;
            }
            else return null;
        }

        public List<ProstorRezervisani> ReadAll()
        {
            return  _context.RezervisaniDatumi.Include(x => x.MojProstor).ToList();
        }

        public void Update(ProstorRezervisani modifiedPR)
        {
            ProstorRezervisani pr = _context.RezervisaniDatumi.Find(modifiedPR.Id);
            if(pr!=null)
            {
                pr.datum = modifiedPR.datum;
                pr.MojProstor = modifiedPR.MojProstor;
                _context.RezervisaniDatumi.Update(pr);
                _context.SaveChanges();
            }
        }
    }
}
