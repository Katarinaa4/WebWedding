using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace WebWedding.Pages.KorisnikPages
{
    public class KorisnikUspesnoStePoslaliZahtevModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public KorisnikUspesnoStePoslaliZahtevModel(WebWeddingContext db)
        {
            _db = db;

        }
        public bool parse { get; set; }
        public int KorisnikID { get; set; }
        public async Task<IActionResult> OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idKorisnik"), out int idKorisnik);
            if (parse)
            {
                KorisnikID = idKorisnik;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
    }
}