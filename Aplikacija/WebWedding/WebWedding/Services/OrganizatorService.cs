using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;


namespace WebWedding.Services
{
    public interface IOrganizatorService
    {
        List<Organizator> ReadAll();
        void Create(Organizator o);
        Organizator Read(int id);
        void Update(Organizator modifiedO);
        void Delete(int id);
    }
    public class OrganizatorService : IOrganizatorService
    {
        private readonly WebWeddingContext _context;

        public OrganizatorService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(Organizator o)
        {
            _context.Organizatori.Add(o);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Organizator o = _context.Organizatori.Find(id);
            if (o != null)
            {
                _context.Organizatori.Remove(o);
                _context.SaveChanges();
            }
        }

        public Organizator Read(int id)
        {
            Organizator o = _context.Organizatori.Where(x => x.Id == id).FirstOrDefault();
            if (o != null)
            {
                return o;
            }
            else return null;
        }

        public List<Organizator> ReadAll()
        {
            return _context.Organizatori.ToList();
        }

        //ovaj Update azurira samo osnovne informacije o Adminu
        public void Update(Organizator modifiedO)
        {
            Organizator o = _context.Organizatori.Find(modifiedO.Id);
            if (o != null)
            {
                o.Ime = modifiedO.Ime;
                o.Prezime = modifiedO.Prezime;
                o.Sifra = modifiedO.Sifra;
                o.Email = modifiedO.Email;
            }
        }
    }
}
