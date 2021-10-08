using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;


namespace WebWedding.Services
{
    public interface IAdminService
    {
        List<Administrator> ReadAll();
        void Create(Administrator a);
        Administrator Read(int id);
        void Update(Administrator modifiedA);
        void Delete(int id);
    }
    public class AdminService : IAdminService
    {
        private readonly WebWeddingContext _context;

        public AdminService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(Administrator a)
        {
            _context.Administrator.Add(a);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Administrator a = _context.Administrator.Find(id);
            if (a != null)
            {
                _context.Administrator.Remove(a);
                _context.SaveChanges();
            }
        }

        public Administrator Read(int id)
        {
            Administrator a = _context.Administrator.Where(x => x.Id == id).FirstOrDefault();
            if (a != null)
            {
                return a;
            }
            else return null;
        }

        public List<Administrator> ReadAll()
        {
            return _context.Administrator.ToList();
        }

        //ovaj Update azurira samo osnovne informacije o Adminu
        public void Update(Administrator modifiedA)
        {
            Administrator a = _context.Administrator.Find(modifiedA.Id);
            if (a != null)
            {
                a.Ime = modifiedA.Ime;
                a.Prezime = modifiedA.Prezime;
                a.Sifra = modifiedA.Sifra;
                a.Email = modifiedA.Email;
            }
        }
    }
}
