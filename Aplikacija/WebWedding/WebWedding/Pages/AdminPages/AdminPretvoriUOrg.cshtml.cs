using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.AdminPages
{
    public class AdminPretvoriUOrgModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public Korisnik Korisnik { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminPretvoriUOrgModel(WebWeddingContext _db)
        {
            _context = _db;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                if (id == null)
                {
                    return NotFound();
                }

                Korisnik = await _context.Korisnici.FirstOrDefaultAsync(m => m.Id == id);

                if (Korisnik == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else return RedirectToPage("../Index");
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (id == null)
                {
                    return NotFound();
                }
                //Korisnik = await _context.Korisnici.FindAsync(id);
                Korisnik = await _context.Korisnici.Include(x => x.MojZahtev).Include(x => x.Narudzbine).FirstOrDefaultAsync(m => m.Id == id);
                if (Korisnik != null)
                {
                    Organizator Organizator = new Organizator();
                    Organizator.Ime = Korisnik.Ime;
                    Organizator.Prezime = Korisnik.Prezime;
                    Organizator.Email = Korisnik.Email;
                    Organizator.Sifra = Korisnik.Sifra;
                    Organizator.Plata = 30000;

                    _context.Organizatori.Add(Organizator);
                    await _context.SaveChangesAsync();

                    if(Korisnik.MojZahtev!=null)
                    {
                        _context.Zahtevi.Remove(Korisnik.MojZahtev);
                    }
                    if (Korisnik.Narudzbine.Count != 0)
                    {
                        foreach (Narudzbina n in Korisnik.Narudzbine)
                            _context.Narudzbine.Remove(n);
                    }

                    _context.Korisnici.Remove(Korisnik);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledKorisnika");
            }
            else return RedirectToPage("../Index");
        }
    }

}