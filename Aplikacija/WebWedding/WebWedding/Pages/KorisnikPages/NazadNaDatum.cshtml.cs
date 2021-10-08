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
    public class NazadNaDatumModel : PageModel
    {
        public WebWeddingContext _db { get; set; }


        [BindProperty]
        public Zahtev zahtev { get; set; }
        public int? idKorisnik { get; set; }
        public bool parse { get; set; }
        public int? jedinica { get; set; }

        [BindProperty]
        public bool maliDatum { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public NazadNaDatumModel(WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                maliDatum = false;
                return Page();
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
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                maliDatum = false;
                zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostDaljeAsync()
        {

            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                //zahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (zahtev.IzabraniDatum <= DateTime.Today.AddDays(10))
                {
                    maliDatum = true;
                    return Page();
                }
                else
                {



                    await _db.SaveChangesAsync();
                    return RedirectToPage("../KorisnikPages/KorisnikZahtevPrikazSlobodnihProstora");
                }

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
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);

                await _db.SaveChangesAsync();
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");

            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }

}