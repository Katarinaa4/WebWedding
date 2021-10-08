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
    public class GreskaAdreseModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public GreskaAdreseModel(WebWeddingContext db)
        {
            _db = db;
        }

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
            }
            else
            {
                ZaKorisnika = false;
            }
            return Page();
        }

        public async Task<ActionResult> OnPostZatvoriAsync()
        {
            return RedirectToPage("../StraniceNaPocetnoj/PlanerProdavnica");
        }
    }
}
