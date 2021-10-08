using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWedding;

namespace WebWedding.Pages.OrganizatorPages
{
    public class OrganizatorPodesavanjeNalogaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        public OrganizatorPodesavanjeNalogaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organizator Organizator { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;


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
            

            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

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

            return RedirectToPage("./OrganizatorPocetna");
        }

        private bool OrganizatorExists(int id)
        {
            return _context.Organizatori.Any(e => e.Id == id);
        }
    }
}
