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
    public class PrikazMenijaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public ICollection<Meni> listaMenija { get; set; }

        public PrikazMenijaModel(WebWeddingContext db)
        {
            _db = db;
        }

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
                if (zahtev == null)
                {
                    ImaZahtev = false;
                }
                else
                {
                    ImaZahtev = true;
                }
                ZaKorisnika = true;
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
                return Page();
            }
            else
            {
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
                ZaKorisnika = false;
                return Page();
            }
        }


    }
}
