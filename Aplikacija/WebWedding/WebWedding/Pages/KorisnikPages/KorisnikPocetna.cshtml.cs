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
    public class KorisnikPocetnaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public int? idKorisnik { get; set; }
        public Korisnik Korisnik { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public Zahtev MojZahtev { get; set; }
        public bool ImaVecZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public KorisnikPocetnaModel(WebWeddingContext db)
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
                
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev==null)
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
    }
}