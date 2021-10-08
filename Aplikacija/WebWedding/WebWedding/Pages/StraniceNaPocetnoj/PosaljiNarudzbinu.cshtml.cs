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
    public class PosaljiNarudzbinuModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public PosaljiNarudzbinuModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public double cenaUkupna { get; set; }

        public bool parse { get; set; }

        public bool ZaKorisnika { get; set; }

        public bool ImaZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public ICollection<Narudzbina> listaN { get; set; }

        public async Task<ActionResult> OnGetAsync(double cena)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (zahtev == null)
                {
                    ImaZahtev = false;
                }
                else
                {
                    ImaZahtev = true;
                }
                ZaKorisnika = true;
                cenaUkupna = cena;
                return Page();
            }
            else
            {
                ZaKorisnika = false;
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostNaruciAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                listaN =  await _db.Narudzbine.Include(x => x.MojPlaner).Where(x => x.MojKorisnik == korisnik).ToListAsync();
                foreach(var nar in listaN)
                {
                    if (nar.Status == null)
                    {
                        if (nar.MojPlaner.BrojPlaneraNaRaspolaganju > 0)
                        {
                            nar.MojPlaner.BrojPlaneraNaRaspolaganju--;
                            nar.Status = "Naruceno";
                        }
                        else
                        {
                            nar.Status = "Rasprodato";
                        }
                        
                    }
                }
                
                await _db.SaveChangesAsync();
                return RedirectToPage("../StraniceNaPocetnoj/UspesnaNarudzbina");
            }
            else
            {
                return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
            }
        }

        public async Task<ActionResult> OnPostNazadAsync()
        {
            return RedirectToPage("../StraniceNaPocetnoj/PlanerProdavnica");
        }


    }
}
