using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.KorisnikPages
{
    public class KorisnikBrojGostijuModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public bool parse { get; set; }

        public Zahtev MojZahtev { get; set; }
        [BindProperty]
        public int? BrojGostiju { get; set; }
        public int? jedinica { get; set; }
        public bool ProstorNull { get; set; }
        [BindProperty]
        public bool Prekoraceno { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public KorisnikBrojGostijuModel(WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
              //  Prekoraceno = false;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev.MojProstor == null)
                {
                    ProstorNull = true;
                    return Page();
                }
                else
                {
                    BrojGostiju = MojZahtev.BrojGostiju;
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            jedinica = id;
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev.MojProstor == null)
                {
                    ProstorNull = true;
                    return Page();
                }
                else
                {
                    BrojGostiju = MojZahtev.BrojGostiju;
                    return Page();
                }
                
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostIzaberiAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x=> x.MojProstor).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (BrojGostiju > MojZahtev.MojProstor.Kapacitet)
                {
                    Prekoraceno = true;
                    return Page();
                }
                else
                {
                    MojZahtev.BrojGostiju = BrojGostiju;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborMenija");
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                MojZahtev.BrojGostiju = BrojGostiju;
                await _db.SaveChangesAsync();
                return RedirectToPage("../KorisnikPages/KorisnikZahtevPrikazSlobodnihProstora");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNaPregledAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (BrojGostiju > MojZahtev.MojProstor.Kapacitet)
                {
                    Prekoraceno = true;
                    return Page();
                }
                else
                {
                    MojZahtev.BrojGostiju = BrojGostiju;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNazadZaPotvrduAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
        public async Task<IActionResult> OnPostIdiNaProstorAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return RedirectToPage("../KorisnikPages/KorisnikZahtevPrikazSlobodnihProstora");
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
    }
}