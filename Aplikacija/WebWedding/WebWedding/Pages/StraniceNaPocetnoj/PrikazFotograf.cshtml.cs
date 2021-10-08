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
    public class PrikazFotografModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        [BindProperty]
        public ICollection<Fotograf> mojiFotografi { get; set; }

        public PrikazFotografModel(WebWeddingContext db)
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
            
            mojiFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            foreach (var fotograf in mojiFotografi)
            {
                if (fotograf.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiFotografaAsync(fotograf.Id);
                }
            }

        }
        
        public async Task<ActionResult> OnPostObrisiFotografaAsync(int id)
        {
            Fotograf zaBrisanje = await _db.Fotografi.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

            _db.Fotografi.Remove(zaBrisanje);

            List<FotografRezervisani> rezervisani = await _db.FotografiRezervisaniD.Include(x => x.MojFotograf).ToListAsync();
            foreach (var rez in rezervisani)
            {
                if (rez.MojFotograf == null)
                    _db.FotografiRezervisaniD.Remove(rez);
            }

            List<FotografZakazani> zakazani = await _db.FotografiZakazaniD.Include(x => x.MojFotograf).ToListAsync();
            foreach (var zak in zakazani)
            {
                if (zak.MojFotograf == null)
                    _db.FotografiZakazaniD.Remove(zak);
            }

            await _db.SaveChangesAsync();
            return RedirectToPage();

        }

    }
}
