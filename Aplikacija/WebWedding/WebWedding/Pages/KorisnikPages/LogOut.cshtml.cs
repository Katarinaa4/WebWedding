using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.KorisnikPages
{
   
    public class LogOutModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public bool parse { get; set; }
        public bool ImaVecZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public LogOutModel(WebWeddingContext db)
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
        public async Task<IActionResult> OnPostLogOutAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {

                HttpContext.Session.Remove("idKorisnik");
            }
            return RedirectToPage("../Index");
        }
        public async Task<IActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                return RedirectToPage("../KorisnikPages/KorisnikPocetna");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}