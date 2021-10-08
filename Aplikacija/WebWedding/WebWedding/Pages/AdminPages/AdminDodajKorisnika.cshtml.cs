using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding
{
    public class AdminDodajKorisnikaModel : PageModel
    {

        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminDodajKorisnikaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        [BindProperty]
        public Korisnik Korisnik { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Korisnik.Arhivirano = false;
                _context.Korisnici.Add(Korisnik);
                await _context.SaveChangesAsync();

                return RedirectToPage("./AdminPregledKorisnika");
            }
            else return RedirectToPage("../Index");
        }
    }

}