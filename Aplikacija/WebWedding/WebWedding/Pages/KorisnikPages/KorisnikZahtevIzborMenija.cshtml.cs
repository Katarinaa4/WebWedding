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
    public class KorisnikZahtevIzborMenijaModel : PageModel
    {

        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public Prostor MojProstor { get; set; }

        [BindProperty]
        public ICollection<Meni> mojiMeniji { get; set; }
        [BindProperty]
        public int? IzabraniMeni { get; set; }
        [BindProperty]
        public Zahtev MojZahtev { get; set; }

        [BindProperty]
        public bool parse { get; set; }
        [BindProperty]
        public Meni MojPrethodniMeni { get; set; }
        public int? jedinica { get; set; }
        public bool OvoJeZaNullIzaberi { get; set; }
        public bool PotvrdiDaNeZelis { get; set; }
        public bool ProstorNull { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }

        public KorisnikZahtevIzborMenijaModel(WebWeddingContext db)
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
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev.MojProstor != null)
                {
                    MojProstor = MojZahtev.MojProstor;

                    MojPrethodniMeni = MojZahtev.MojMeni;

                    mojiMeniji = await _db.Meniji.Where(x => x.MojProstor == MojProstor).ToListAsync();
                    return Page();
                }
                else
                {
                    ProstorNull = true;
                    return Page();
                }
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

                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();
                if (MojZahtev.MojProstor != null)
                {
                    MojProstor = MojZahtev.MojProstor;

                    MojPrethodniMeni = MojZahtev.MojMeni;
                    if(MojPrethodniMeni!=null)
                    {
                        MojZahtev.UkupnaCena = MojZahtev.UkupnaCena - (double)(MojZahtev.MojMeni.Cena * MojZahtev.BrojGostiju);

                    }
                    mojiMeniji = await _db.Meniji.Where(x => x.MojProstor == MojProstor).ToListAsync();
                    await _db.SaveChangesAsync();
                    return Page();
                }
                else
                {
                    ProstorNull = true;
                    return Page();
                }
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
                Meni tmp = await _db.Meniji.FindAsync(IzabraniMeni);
                MojZahtev.UkupnaCena += tmp.Cena * (double)MojZahtev.BrojGostiju;
                MojZahtev.MojMeni = tmp;
                await _db.SaveChangesAsync();


                return RedirectToPage("../KorisnikPages/KorisnikZahtevIzborBenda");
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
                return RedirectToPage("../KorisnikPages/KorisnikBrojGostiju");

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
                MojZahtev = await _db.Zahtevi.Include(x => x.MojProstor).Include(x => x.MojMeni).Where(x => x.MojKorisnik == korisnik).FirstOrDefaultAsync();

                Meni tmp = await _db.Meniji.FindAsync(IzabraniMeni);
                MojZahtev.UkupnaCena += tmp.Cena * (double)MojZahtev.BrojGostiju;
                MojZahtev.MojMeni = tmp;
                await _db.SaveChangesAsync();

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
                return RedirectToPage("../KorisnikPages/KorisnikPregledZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
        public async Task<IActionResult> OnPostIdiNaProstorAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return RedirectToPage("../KorisnikPages/KorisnikZahtevPrikazSlobodnihProstora");
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
    }
}
