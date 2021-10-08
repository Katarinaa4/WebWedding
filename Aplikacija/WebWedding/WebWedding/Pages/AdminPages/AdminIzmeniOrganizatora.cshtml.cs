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
    public class AdminIzmeniOrganizatoraModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        public AdminIzmeniOrganizatoraModel(WebWedding.WebWeddingContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(Organizator).State = EntityState.Modified;

                try
                {
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizatorExists(Organizator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./AdminPregledOrganizatora");
            }
            else return RedirectToPage("../Index");
        }

        private bool OrganizatorExists(int id)
        {
            return _context.Organizatori.Any(e => e.Id == id);
        }
    }
}