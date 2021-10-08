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
    public class PrikazDekoracijaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }

        [BindProperty]
        public int KorisnikID { get; set; }
        [BindProperty]
        public ICollection<Dekoracija> mojaDekoracija { get; set; }
        public PrikazDekoracijaModel(WebWeddingContext db)
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
            
            mojaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            

            foreach (var dekoracija in mojaDekoracija)
            {
                if (dekoracija.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiDekoracijuAsync(dekoracija.Id);
                }
            }

        }

        public async Task<ActionResult> OnPostObrisiDekoracijuAsync(int id)
        {
            Dekoracija zaBrisanje = await _db.Dekoracije.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

            _db.Dekoracije.Remove(zaBrisanje);

            List<DekoracijaRezervisani> rezervisani = await _db.DekoracijaRezervisaniD.Include(x => x.MojaDekoracija).ToListAsync();
            foreach (var rez in rezervisani)
            {
                if (rez.MojaDekoracija == null)
                    _db.DekoracijaRezervisaniD.Remove(rez);
            }

            List<DekoracijaZakazani> zakazani = await _db.DekoracijaZakazaniD.Include(x => x.MojaDekoracija).ToListAsync();
            foreach (var zak in zakazani)
            {
                if (zak.MojaDekoracija == null)
                    _db.DekoracijaZakazaniD.Remove(zak);
            }

            await _db.SaveChangesAsync();
            return RedirectToPage();

        }
    }
}
