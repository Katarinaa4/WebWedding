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
    public class AdminObrisiOrganizatoraModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        public AdminObrisiOrganizatoraModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organizator Organizator { get; set; }
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

                Organizator = await _context.Organizatori.FirstOrDefaultAsync(m => m.Id == id);

                if (Organizator == null)
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

                Organizator = await _context.Organizatori.FindAsync(id);

                if (Organizator != null)
                {
                    _context.Organizatori.Remove(Organizator);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledArhiviranihOrganizatora");
            }
            else return RedirectToPage("../Index");
        }
    }
}