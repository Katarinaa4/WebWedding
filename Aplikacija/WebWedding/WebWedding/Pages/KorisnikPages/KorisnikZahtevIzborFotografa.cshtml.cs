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
    public class KorisnikZahtevIzborFotografaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
       
        public bool parse { get; set; }
        [BindProperty]
        public ICollection<Fotograf> SviFotografi { get; set; }
        public Zahtev MojZahtev { get; set; }
        [BindProperty]
        public int? Stiklirano { get; set; }
        [BindProperty]
        public bool R { get; set; }
        [BindProperty]
        public bool Z { get; set; }
        [BindProperty]
        public Fotograf PrethodniFotograf { get; set; }
        public int? jedinica { get; set; }
        public bool PotvrdiDaNeZelis { get; set; }
        public bool OvoJeZaNullIzaberi { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public KorisnikZahtevIzborFotografaModel(WebWeddingContext db)
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
                SviFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                PrethodniFotograf = MojZahtev.MojFotograf;
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
                SviFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                PrethodniFotograf = MojZahtev.MojFotograf;
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
                if(Stiklirano !=null)
                {
                    Fotograf tmp = await _db.Fotografi.FindAsync(Stiklirano);
                    MojZahtev.MojFotograf = tmp;
                    if (PrethodniFotograf != null)
                    {
                        MojZahtev.UkupnaCena -= PrethodniFotograf.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    OvoJeZaNullIzaberi = true;
                    PotvrdiDaNeZelis = true;

                    return Page();
                }
               
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborDekoracije");
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
                if (Stiklirano!=null)
                {
                    Fotograf tmp = await _db.Fotografi.FindAsync(Stiklirano);
                    MojZahtev.MojFotograf = tmp;
                    if (PrethodniFotograf != null)
                    {
                        MojZahtev.UkupnaCena -= PrethodniFotograf.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
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
        public async Task<IActionResult> OnPostNazadZaPotvrduAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                SviFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                //jedinica = 1;
                PotvrdiDaNeZelis = false;
                return Page();
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
                Fotograf tmp = await _db.Fotografi.FindAsync(Stiklirano);
                
                if (PrethodniFotograf != null)
                {
                    MojZahtev.UkupnaCena -= PrethodniFotograf.Cena;
                }
                if (tmp!=null)
                {
                    MojZahtev.MojFotograf = tmp;
                    MojZahtev.UkupnaCena += tmp.Cena;
                    await _db.SaveChangesAsync();
                }
              
               
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborBenda");

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
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborDekoracije");
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
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).Include(x => x.MojFotograf).FirstOrDefaultAsync();
                SviFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                MojZahtev.MojFotograf = null;
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
