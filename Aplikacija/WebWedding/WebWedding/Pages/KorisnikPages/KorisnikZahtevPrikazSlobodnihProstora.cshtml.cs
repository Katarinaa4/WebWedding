using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.KorisnikPages
{
    public class KorisnikZahtevPrikazSlobodnihModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public ICollection<Prostor> mojiProstori { get; set; }
        public Prostor Izabrano { get; set; }
        public Zahtev MojZahtev { get; set; }
        [BindProperty]
        public int? Stiklirano { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public bool R { get; set; }
        [BindProperty]
        public bool Z { get; set; }
        [BindProperty]
        public int? BrojGostiju { get; set; }
        [BindProperty]

        public int? jedinica { get; set; }
        public bool PotvrdiDaNeZelis { get; set; }
        public bool OvoJeZaNullIzaberi { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public KorisnikZahtevPrikazSlobodnihModel(WebWeddingContext db)
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
                mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                jedinica = 0;
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
                mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
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
                    Prostor tmp = await _db.Prostori.FindAsync(Stiklirano);
                    MojZahtev.MojProstor = tmp;
                     await _db.SaveChangesAsync();
                }
                else
                {
      
                    OvoJeZaNullIzaberi = true;
                    PotvrdiDaNeZelis = true;

                    return Page();
                }

                return RedirectToPage("../KorisnikPages/KorisnikBrojGostiju");
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
                Prostor tmp = await _db.Prostori.FindAsync(Stiklirano);
                MojZahtev.MojProstor = tmp;
          
                
                await _db.SaveChangesAsync();
                return RedirectToPage("../KorisnikPages/NazadNaDatum");

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
                    Prostor tmp = await _db.Prostori.FindAsync(Stiklirano);
                    MojZahtev.MojProstor = tmp;

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
                mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
               // jedinica = 1;
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
                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborBenda");
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
                MojZahtev = await _db.Zahtevi.Where(x => x.MojKorisnik == korisnik).Include(x=>x.MojProstor).FirstOrDefaultAsync();
                mojiProstori = await _db.Prostori.Include(x => x.Rezervisani).Include(x => x.Zakazani).ToListAsync();
                MojZahtev.MojProstor = null;
                MojZahtev.BrojGostiju = null;
                MojZahtev.MojMeni = null;
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



    
