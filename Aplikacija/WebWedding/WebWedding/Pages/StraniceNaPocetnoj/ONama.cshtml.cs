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
    public class ONamaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public ICollection<Prostor> mojiProstori { get; set; }

        [BindProperty]
        public ICollection<Muzika> mojaMuzika { get; set; }

        [BindProperty]
        public ICollection<Fotograf> mojiFotografi { get; set; }

        [BindProperty]
        public ICollection<Dekoracija> mojaDekoracija { get; set; }

        public bool parse { get; set; }
        public bool ZaKorisnika { get; set; }
        public bool ImaZahtev { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public ONamaModel(WebWeddingContext db)
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
                if(zahtev==null)
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
            mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x=>x.StatusPrikaza=="Prikaz").ToListAsync();

            mojaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            mojiFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            mojaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

            foreach (var prostor in mojiProstori)
            {
                if (prostor.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiProstorAsync(prostor.Id);
                }
            }

            foreach (var muzika in mojaMuzika)
            {
                if (muzika.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiMuzikuAsync(muzika.Id);
                }
            }

            foreach (var fotograf in mojiFotografi)
            {
                if (fotograf.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiFotografaAsync(fotograf.Id);
                }
            }

            foreach (var dekoracija in mojaDekoracija)
            {
                if (dekoracija.DatumVazenja == DateTime.Now)
                {
                    OnPostObrisiDekoracijuAsync(dekoracija.Id);
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