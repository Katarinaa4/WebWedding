using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebWedding.Pages.Kalendari
{
    public class KorisnikKalendarMuzikaModel : PageModel
    {
        public bool parse { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        public async Task<IActionResult> OnGetAsync()
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