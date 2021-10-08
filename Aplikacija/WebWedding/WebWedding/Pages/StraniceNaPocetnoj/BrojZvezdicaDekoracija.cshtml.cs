using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.StraniceNaPocetnoj
{
    public class BrojZvezdicaDekoracijaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public bool parse { get; set; }

        [BindProperty]
        public int Broj { get; set; }

        public bool ImaVecZahtev { get; set; }

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public BrojZvezdicaDekoracijaModel(WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                Zahtev MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev == null)
                {
                    ImaVecZahtev = false;
                }
                else
                {
                    ImaVecZahtev = true;
                }

                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostIzracunajAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                var korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                var pom = await _db.Korisnici.Include(x => x.MojZahtev).FirstOrDefaultAsync();
                var pom1 = await _db.Zahtevi.Include(x => x.MojaDekoracija).FirstOrDefaultAsync();
                var pom2 = await _db.Dekoracije.Where(x => x.Id == pom1.MojaDekoracija.Id).FirstOrDefaultAsync();

                if (pom2.Id == ID)
                {
                    var dekoracija = await _db.Dekoracije.FindAsync(ID);
                    if ((dekoracija.BrojZvezdica + Broj) / 2 < 5)
                    {
                        dekoracija.BrojZvezdica = (dekoracija.BrojZvezdica + Broj) / 2;
                    }
                    else
                    {
                        dekoracija.BrojZvezdica = 5;
                    }
                    await _db.SaveChangesAsync();

                }
                return RedirectToPage("../StraniceNaPocetnoj/PrikazDekoracija");
            }
            return RedirectToPage("../Index");
        }
    }
}
