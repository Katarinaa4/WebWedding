using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding;
using WebWedding.Models;

namespace WebWedding.Pages.AdminPages
{
    public class AdminObrisiNarudzbinuModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;

        public AdminObrisiNarudzbinuModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Narudzbina Narudzbina { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public bool parse { get; set; }

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

                Narudzbina = await _context.Narudzbine.Include(x => x.MojPlaner).FirstOrDefaultAsync(m => m.Id == id);

                if (Narudzbina == null)
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

                Narudzbina = await _context.Narudzbine.FindAsync(id);

                if (Narudzbina != null)
                {
                    _context.Narudzbine.Remove(Narudzbina);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledArhiviranihNarudzbina");
            }
            else return RedirectToPage("../Index");
        }
    }
}
