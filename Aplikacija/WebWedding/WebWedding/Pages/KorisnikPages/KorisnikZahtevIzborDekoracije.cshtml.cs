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
    public class KorisnikZahtevIzborDekoracijeModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public ICollection<Dekoracija> SvaDekoracija { get; set; }
        public Zahtev MojZahtev { get; set; }
        [BindProperty]
        public int? Stiklirano { get; set; }
        [BindProperty]
        public bool R { get; set; }
        [BindProperty]
        public bool Z { get; set; }
        [BindProperty]
        public Dekoracija Prethodna { get; set; }
        public int? jedinica { get; set; }
        public bool PotvrdiDaNeZelis { get; set; }
        public bool OvoJeZaNullIzaberi { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public KorisnikZahtevIzborDekoracijeModel(WebWeddingContext db)
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
                SvaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                Prethodna = MojZahtev.MojaDekoracija;
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
                SvaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                Prethodna = MojZahtev.MojaDekoracija;
                return Page();
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
                    Dekoracija tmp = await _db.Dekoracije.FindAsync(Stiklirano);
                    if (Prethodna != null)
                    {
                        MojZahtev.UkupnaCena -= Prethodna.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaDekoracija = tmp;
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
                    Dekoracija tmp = await _db.Dekoracije.FindAsync(Stiklirano);
                    if (Prethodna != null)
                    {
                        MojZahtev.UkupnaCena -= Prethodna.Cena;
                    }
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaDekoracija = tmp;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    OvoJeZaNullIzaberi = true;
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
                Dekoracija tmp = await _db.Dekoracije.FindAsync(Stiklirano);
                if (Prethodna != null)
                {
                    MojZahtev.UkupnaCena -= Prethodna.Cena;
                }
                if (tmp!=null)
                {
                    MojZahtev.UkupnaCena += tmp.Cena;
                    MojZahtev.MojaDekoracija = tmp;
                    await _db.SaveChangesAsync();
                }
                
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborFotografa");

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
                SvaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
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
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
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
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).Include(x => x.MojaDekoracija).FirstOrDefaultAsync();
                SvaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                MojZahtev.MojaDekoracija = null;
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