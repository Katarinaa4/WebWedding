using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebWedding.Pages.StraniceNaPocetnoj
{
    public class GreskaRegistrovanjaModel : PageModel
    {
       
            public WebWeddingContext _db { get; set; }

            public GreskaRegistrovanjaModel(WebWeddingContext db)
            {
                _db = db;
            }

            [BindProperty]
            public Korisnik NovKorisnik { get; set; }

            public bool pomocna { get; set; }

            public string sifra { get; set; }

            public void OnGet()
            {

            }

        public async Task<ActionResult> OnPostRegistrujAsync()
        {
           

           // if (NovKorisnik.Sifra != sifra)
             //return RedirectToPage("../StraniceNaPocetnoj/Registracija");


            foreach (Korisnik korisnik in _db.Korisnici)
            {
                if (korisnik.Email == NovKorisnik.Email)
                {
                    pomocna = true;
                }
                else
                {
                    pomocna = false;
                }
            }

            if (pomocna)
            {
                return RedirectToPage("../StraniceNaPocetnoj/GreskaRegistrovanja");
            }

            await _db.Korisnici.AddAsync(NovKorisnik);
            await _db.SaveChangesAsync();
            return RedirectToPage("../StraniceNaPocetnoj/Logovanje");
        }
    
}
}
