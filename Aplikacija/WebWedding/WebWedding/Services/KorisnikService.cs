using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;
using WebWedding.Pages.KorisnikPages;

namespace WebWedding.Services
{
    public interface IKorisnikService
    {
        List<Korisnik> ReadAll();
        void Create(Korisnik k);
        Korisnik Read(int id);
        void Update(Korisnik modifiedK);
        void Delete(int id);
    }
    public class KorisnikService : IKorisnikService
    {
        private readonly WebWeddingContext _context;

        public KorisnikService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(Korisnik k)
        {
            _context.Korisnici.Add(k);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Korisnik k = _context.Korisnici.Find(id);
            if (k != null)
            {
                _context.Korisnici.Remove(k);
                _context.SaveChanges();
            }
        }

        public Korisnik Read(int id)
        {
            Korisnik k = _context.Korisnici.Where(x => x.Id == id).FirstOrDefault();
            if (k != null)
            {
                return k;
            }
            else return null;
        }

        public List<Korisnik> ReadAll()
        {
            return _context.Korisnici.ToList();
        }

        //ovaj Update azurira samo osnovne informacije o Korisniku
        public void Update(Korisnik modifiedK)
        {
            Korisnik k = _context.Korisnici.Find(modifiedK.Id);
            if (k != null)
            {
                k.Ime = modifiedK.Ime;
                k.Prezime = modifiedK.Prezime;
                k.Sifra = modifiedK.Sifra;
                k.Email = modifiedK.Email;
                k.BrojTelefona = modifiedK.BrojTelefona;
            }
        }
    }
}
