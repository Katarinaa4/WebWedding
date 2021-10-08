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
    public class PrikazMuzikaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }

        [BindProperty]
        public ICollection<Muzika> mojaMuzika { get; set; }

        public PrikazMuzikaModel(WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int KorisnikID { get; set; }
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

            mojaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            foreach (var muzika in mojaMuzika)
            {
                if (muzika.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiMuzikuAsync(muzika.Id);
                }
            }

        }
        public async Task<ActionResult> OnPostObrisiMuzikuAsync(int id)
        {
            Muzika zaBrisanje = await _db.Muzika.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

            _db.Muzika.Remove(zaBrisanje);

            List<MuzikaRezervisani> rezervisani = await _db.MuzikaRezervisaniD.Include(x => x.MojaMuzika).ToListAsync();
            foreach (var rez in rezervisani)
            {
                if (rez.MojaMuzika == null)
                    _db.MuzikaRezervisaniD.Remove(rez);
            }

            List<MuzikaZakazani> zakazani = await _db.MuzikaZakazaniD.Include(x => x.MojaMuzika).ToListAsync();
            foreach (var zak in zakazani)
            {
                if (zak.MojaMuzika == null)
                    _db.MuzikaZakazaniD.Remove(zak);
            }

            await _db.SaveChangesAsync();
            return RedirectToPage();

        }

    }
}
