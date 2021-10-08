using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.StraniceNaPocetnoj
{
    public class PlanerProdavnicaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public PlanerProdavnicaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public ICollection<Planer> listaPlanera { get; set; }

        public bool parse { get; set; }

        public bool ImaZahtev { get; set; }

        public bool ZaKorisnika { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                ZaKorisnika = true;
                if (zahtev == null)
                {
                    ImaZahtev = false;
                }
                else
                {
                    ImaZahtev = true;
                }
                listaPlanera = await _db.Planeri.ToListAsync();
                return Page();
            }
            else
            {
                listaPlanera = await _db.Planeri.ToListAsync();
                ZaKorisnika = false;
                return Page();
            }
        }

        public async Task<ActionResult> OnPostDodajAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                var korisnik = await _db.Korisnici.Where(x => x.Id == idKorisnik).FirstOrDefaultAsync();
                var planer = await _db.Planeri.Where(x => x.Id == id).FirstOrDefaultAsync();

                
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
            }
        }
    }
}
