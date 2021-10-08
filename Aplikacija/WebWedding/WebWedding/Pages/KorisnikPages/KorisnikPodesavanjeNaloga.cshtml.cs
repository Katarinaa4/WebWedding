using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWedding;

namespace WebWedding.Pages.KorisnikPages
{
    public class KorisnikPodesavanjeNalogaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        public KorisnikPodesavanjeNalogaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public bool ImaZahtev { get; set; }

        [BindProperty]
        public Korisnik Korisnik { get; set; }

        [BindProperty]
        public int KorisnikID { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _context.Korisnici.FindAsync(idKorisnik);
                Zahtev zahtev = await _context.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (zahtev == null)
                {
                    ImaZahtev = false;
                }
                else
                {
                    ImaZahtev = true;
                }

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

        public async Task<IActionResult> OnPostAsync()
        {
            /* Administrator stariAdmin= await _context.Administrator.FirstOrDefaultAsync(m => m.Id == Administrator.Id);
             if (Administrator.Ime==null)
             {
                 Administrator.Ime = stariAdmin.Ime;
             }

             if (Administrator.Prezime == null)
             {
                 Administrator.Prezime = stariAdmin.Prezime;
             }

             if (Administrator.Email == null)
             {
                 Administrator.Email = stariAdmin.Email;
             }

             if (Administrator.Sifra == null)
             {
                 Administrator.Sifra = stariAdmin.Sifra;
             }*/

            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(Korisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(Korisnik.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./KorisnikPocetna");
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnici.Any(e => e.Id == id);
        }
    }
}
