using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;


namespace WebWedding.Services
{
    public interface IMeniService
    {
        List<Meni> ReadAll();
        void Create(Meni m);
        Meni Read(int id);
        void Update(Meni modifiedM);
        void Delete(int id);
    }
    public class MeniService : IMeniService
    {
        private readonly WebWeddingContext _context;

        public MeniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(Meni m)
        {
            _context.Meniji.Add(m);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Meni m = _context.Meniji.Find(id);
            if (m != null)
            {
                _context.Meniji.Remove(m);
                _context.SaveChanges();
            }
        }

        public Meni Read(int id)
        {
            Meni m = _context.Meniji.Where(x => x.Id == id).FirstOrDefault();
            if (m != null)
            {
                return m;
            }
            else return null;
        }

        public List<Meni> ReadAll()
        {
            return _context.Meniji.Include(x => x.MojProstor).ToList();
        }

        
        public void Update(Meni modifiedM)
        {
            Meni m = _context.Meniji.Find(modifiedM.Id);
            if (m != null)
            {
                m.Cena = modifiedM.Cena;
                m.Naziv = modifiedM.Naziv;
                m.Opis = modifiedM.Opis;
                m.Status = modifiedM.Status;
                
            }
        }
    }
}
