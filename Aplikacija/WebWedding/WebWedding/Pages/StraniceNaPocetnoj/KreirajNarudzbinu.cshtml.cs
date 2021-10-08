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
    public class KreirajNarudzbinuModel : PageModel
    {
        [BindProperty]
        public int ID { get; set; }

        public WebWeddingContext _db { get; set; }

        public KreirajNarudzbinuModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Planer planer { get; set; }

        [BindProperty]
        public Narudzbina Narudzbina { get; set; }

        public bool parse { get; set; }

        public bool ImaZahtev { get; set; }

        public bool ZaKorisnika { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
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
                ID = id;
                planer = await _db.Planeri.FindAsync(id);
                return Page();
            }
            else
            {
                ZaKorisnika = false;
                ID = id;
                planer = await _db.Planeri.FindAsync(id);
                return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
            }
        }

        public async Task<ActionResult> OnPostPotvrdiAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {

                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                    Planer plane = await _db.Planeri.FindAsync(ID);
                    Narudzbina.MojKorisnik = korisnik;
                    Narudzbina.MojPlaner = plane;
                    Narudzbina.Ime = korisnik.Ime;
                    Narudzbina.Prezime = korisnik.Prezime;
                    Narudzbina.BrojTelefona = korisnik.BrojTelefona;
                    Narudzbina.UkupnaCena = plane.Cena;
                    Narudzbina.Email = korisnik.Email;
                    Narudzbina.Arhivirano = false;

                if (!(Narudzbina.Adresa == null))
                {
                    await _db.Narudzbine.AddAsync(Narudzbina);
                    await _db.SaveChangesAsync();

                    return RedirectToPage("../StraniceNaPocetnoj/PlanerUKorpuObavestenje");
                }
                else
                {
                    return RedirectToPage("../StraniceNaPocetnoj/GreskaAdrese");
                }
            }
            else
            {
                return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
            }
        }

        public async Task<ActionResult> OnPostNazadAsync(int id)
        {

            return RedirectToPage("../StraniceNaPocetnoj/PlanerProdavnica");
        }
     }
}
