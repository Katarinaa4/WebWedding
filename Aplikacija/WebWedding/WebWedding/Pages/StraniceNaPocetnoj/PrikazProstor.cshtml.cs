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
    public class PrikazProstorModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public ICollection<Prostor> mojiProstori { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public PrikazProstorModel(WebWeddingContext db)
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
            mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();


            foreach (var prostor in mojiProstori)
            {
                if (prostor.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiProstorAsync(prostor.Id);
                }
            }

        }

        public async Task<ActionResult> OnPostObrisiProstorAsync(int id)
        {
            Prostor zaBrisanje = await _db.Prostori.Include(x => x.ListaMenija).Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

            _db.Prostori.Remove(zaBrisanje);

            List<Meni> meniji = await _db.Meniji.Include(x => x.MojProstor).ToListAsync();
            foreach (var meni in meniji)
            {
                if (meni.MojProstor == null)
                {
                    _db.Meniji.Remove(meni);
                }
            }

            List<ProstorRezervisani> rezervisani = await _db.RezervisaniDatumi.Include(x => x.MojProstor).ToListAsync();
            foreach (var rez in rezervisani)
            {
                if (rez.MojProstor == null)
                {
                    _db.RezervisaniDatumi.Remove(rez);
                }
            }

            List<ProstorZakazani> zakazani = await _db.ZakazaniDatumi.Include(x => x.MojProstor).ToListAsync();
            foreach (var zak in zakazani)
            {
                if (zak.MojProstor == null)
                {
                    _db.ZakazaniDatumi.Remove(zak);
                }
            }

            await _db.SaveChangesAsync();
            return RedirectToPage();

        }

    }
}
