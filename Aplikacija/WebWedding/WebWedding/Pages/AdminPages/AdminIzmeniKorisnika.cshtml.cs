using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebWedding
{
    public class AdminIzmeniKorisnikaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        public AdminIzmeniKorisnikaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Korisnik Korisnik { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(Korisnik).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(Korisnik.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./AdminPregledKorisnika");
            }
            else return RedirectToPage("../Index");
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnici.Any(e => e.Id == id);
        }
    }
}