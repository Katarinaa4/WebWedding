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
    public class AdminArhivirajZahtevModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        [BindProperty]
        public Zahtev Zahtev { get; set; }
        [BindProperty]
        public int AdminID { get; set; }
        public AdminArhivirajZahtevModel(WebWeddingContext context)
        {
            _context = context;
        }


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

                Zahtev = await _context.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                    .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                    .Include(x => x.MojaMuzika)
                    .Include(x => x.MojaDekoracija).FirstOrDefaultAsync(m => m.Id == id);

                if (Zahtev == null)
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
                Zahtev = await _context.Zahtevi.FindAsync(id);
                if (Zahtev != null)
                    Zahtev.Arhivirano = true;
                await _context.SaveChangesAsync();
                return RedirectToPage("./AdminPregledZahteva");
            }
            else return RedirectToPage("../Index");
        }
    }
}