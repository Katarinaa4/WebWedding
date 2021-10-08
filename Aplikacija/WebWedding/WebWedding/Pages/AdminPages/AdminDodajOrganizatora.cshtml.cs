using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebWedding
{
    public class AdminDodajOrganizatoraModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }
        public AdminDodajOrganizatoraModel(WebWedding.WebWeddingContext context)
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
        public Organizator Organizator { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                Organizator.Arhivirano = false;
                _context.Organizatori.Add(Organizator);
                await _context.SaveChangesAsync();

                return RedirectToPage("./AdminPregledOrganizatora");
            }
            else return RedirectToPage("../Index");
        }
    }
}