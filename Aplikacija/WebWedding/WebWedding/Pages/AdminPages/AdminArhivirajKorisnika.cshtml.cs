using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.AdminPages
{
    public class AdminArhivirajKorisnikaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminArhivirajKorisnikaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Korisnik Korisnik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                if (id == null)
                {
                    return NotFound();
                }

                Korisnik = await _context.Korisnici.FirstOrDefaultAsync(m => m.Id == id);

                if (Korisnik == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Korisnik = await _context.Korisnici.FirstOrDefaultAsync(m => m.Id == id);

                if (Korisnik != null)
                {
                    Korisnik.Arhivirano = true;
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledKorisnika");
            }
            else return RedirectToPage("../Index");
        }
    }
}