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
    public class KorisnikZahtevIzborBendaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public ICollection<Muzika> SvaMuzika { get; set; }
        public Zahtev MojZahtev { get; set; }
        [BindProperty]
        public int? Stiklirano { get; set; }
        [BindProperty]
        public bool R { get; set; }
        [BindProperty]
        public bool Z { get; set; }
        [BindProperty]
        public Muzika PrethodniBend { get; set; }
        public int? jedinica { get; set; }
        public bool PotvrdiDaNeZelis { get; set; }
        public bool OvoJeZaNullIzaberi { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public KorisnikZahtevIzborBendaModel(WebWeddingContext db)
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
                SvaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                PrethodniBend = MojZahtev.MojaMuzika;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            jedinica = id;
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                SvaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                PrethodniBend = MojZahtev.MojaMuzika;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostIzaberiAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);

                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (Stiklirano != null)
                {
                    Muzika tmp = await _db.Muzika.FindAsync(Stiklirano);
                    if (PrethodniBend != null)
                    {
                        MojZahtev.UkupnaCena -= PrethodniBend.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaMuzika = tmp;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    OvoJeZaNullIzaberi = true;
                    PotvrdiDaNeZelis = true;

                    return Page();
                }
                
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborFotografa");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNaPregledAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);

                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (Stiklirano != null)
                {
                    Muzika tmp = await _db.Muzika.FindAsync(Stiklirano);
                    if (PrethodniBend != null)
                    {
                        MojZahtev.UkupnaCena -= PrethodniBend.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaMuzika = tmp;
                    await _db.SaveChangesAsync();
                }
                else
                {

                    OvoJeZaNullIzaberi = false;
                    PotvrdiDaNeZelis = true;

                    return Page();
                }
                
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);

                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                Muzika tmp = await _db.Muzika.FindAsync(Stiklirano);
                if (tmp != null)
                {


                    if (PrethodniBend != null)
                    {
                        MojZahtev.UkupnaCena -= PrethodniBend.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaMuzika = tmp;
                }
                await _db.SaveChangesAsync();
                if (MojZahtev.MojProstor == null)
                {
                    return RedirectToPage("../KorisnikPages/KorisnikZahtevPrikazSlobodnihProstora");
                }
                else
                {

                    return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborMenija");
                }

            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNazadZaPotvrduAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                SvaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                //jedinica = 1;
                PotvrdiDaNeZelis = false;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNeZelimAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostNeZelimProstorAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborFotografa");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostOdcekirajAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).Include(x => x.MojaMuzika).FirstOrDefaultAsync();
                SvaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                MojZahtev.MojaMuzika = null;
                await _db.SaveChangesAsync();

                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}