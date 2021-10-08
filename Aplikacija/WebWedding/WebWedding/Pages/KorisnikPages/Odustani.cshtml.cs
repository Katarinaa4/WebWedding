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
    public class OdustaniModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public OdustaniModel(WebWeddingContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Zahtev MojZahtev { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return Page();
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

                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostOdustaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                korisnik.MojZahtev = null;
                //MojZahtev.MojKorisnik = null;
                MojZahtev.Arhivirano = true;
                MojZahtev.Status = "Odbijen od strane korisnika";
                await _db.SaveChangesAsync();
                return RedirectToPage("../KorisnikPages/KorisnikPocetna");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
        
}