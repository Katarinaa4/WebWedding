using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.StraniceNaPocetnoj
{
    public class RegistracijaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public RegistracijaModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Korisnik NovKorisnik { get; set; }

        public bool pomocna { get; set; }

        public bool sif { get; set; }

        [BindProperty]
        public string sifra { get; set; }

        public void OnGet()
        {
            sif = false;
        }

        public async Task<ActionResult> OnPostRegistrujAsync()
        {
            sif = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (Korisnik korisnik in _db.Korisnici)
            {
                
                if(korisnik.Email==NovKorisnik.Email)
                {
                    pomocna = true;
                }
            }
            if (pomocna != true)
                pomocna = false;

            if (pomocna)
            {
                return Page();
            }
            if (NovKorisnik.Sifra != sifra)
            {
                sif = true;
                return Page();
            }
            NovKorisnik.Arhivirano = false;
            await _db.Korisnici.AddAsync(NovKorisnik);
            await _db.SaveChangesAsync();
            return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
        }
    }
}