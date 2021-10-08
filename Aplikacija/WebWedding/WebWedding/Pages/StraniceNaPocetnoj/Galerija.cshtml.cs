using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWedding.Models;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages
{
    public class GalerijaModel : PageModel
    {

            [BindProperty]
            public IList<Slika> mojeSlike { get; set; }


            public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public GalerijaModel(WebWeddingContext db)
            {
                _db = db;
            }

            public async Task OnGetAsync()
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
            mojeSlike = await _db.Slike.ToListAsync();

            }
        }
    }