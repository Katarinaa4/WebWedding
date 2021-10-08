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
    public class KorpaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public KorpaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public ICollection<Narudzbina> listaNarudzbina { get; set; }

        [BindProperty]
        public double ukupnaCena { get; set; }

        public bool parse { get; set; }

        public bool ImaZahtev { get; set; }

        public bool ZaKorisnika { get; set; }

        public bool praznaKorpa { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                ZaKorisnika = true;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                listaNarudzbina = await _db.Narudzbine.Include(x=>x.MojPlaner).Where(x => x.MojKorisnik == korisnik).ToListAsync();
                praznaKorpa = true;
                foreach(var nar in listaNarudzbina)
                {
                    if (nar.Status == null)
                    {
                        praznaKorpa = false;
                        ukupnaCena = ukupnaCena + nar.UkupnaCena;
                    }
                }
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (zahtev == null)
                {
                    ImaZahtev = false;
                }
                else
                {
                    ImaZahtev = true;
                }
                return Page();
            }
            else
            {
                ZaKorisnika = false;
                return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
            }
        }

        public async Task<ActionResult> OnPostUkloniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                var zaBrisanje = await _db.Narudzbine.Where(x => x.Id == id).FirstOrDefaultAsync();
                _db.Narudzbine.Remove(zaBrisanje);
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
