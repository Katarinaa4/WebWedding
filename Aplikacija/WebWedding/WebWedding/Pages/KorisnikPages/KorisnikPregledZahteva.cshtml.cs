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
    public class KorisnikPregledZahtevaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public KorisnikPregledZahtevaModel (WebWeddingContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Zahtev MojZahtev { get; set; }
        public bool parse { get; set; }
        public bool ImaVecZahtev { get; set; }
        public bool ImaNepotvrdjenih { get; set; }
        public bool Odstani { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
              parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
              if (parse)
              {
                KorisnikID = idKorisnik;
                ImaNepotvrdjenih = false;
                  Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik); 
            
                 MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev == null)
                {
                    ImaVecZahtev = false;
                }
                else
                {
                    ImaVecZahtev = true;
                  
                }
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

                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                MojZahtev.Poslato = true;
                MojZahtev.DatumPodnosenjaZahteva = DateTime.Now;
                await _db.SaveChangesAsync();
                return RedirectToPage("../KorisnikPages/KorisnikUspesnoStePoslaliZahtev");
            
             }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostIzmeniZahtevAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {

                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                MojZahtev.Poslato = false;
                MojZahtev.Status = null;
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostPosaljiPotvrduAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {

                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                MojZahtev.Poslato = true;
                //proveri da li se ovako zove
                MojZahtev.Status = "Potvrdjen";

                await _db.SaveChangesAsync();
                return RedirectToPage("./KorisnikUspesnoStePoslaliZahtev");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public IActionResult OnPostKreirajAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                return RedirectToPage("./KorisnikZahtevIzborDatuma");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostNaknadnoAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                Korisnik korisnik = await _db.Korisnici.FindAsync(idKorisnik);
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Include(x => x.MojFotograf).Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                MojZahtev.Poslato = false;
                MojZahtev.Status = null;
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostOdustaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                
                return RedirectToPage("../KorisnikPages/Odustani");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
       
    }
}