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

namespace WebWedding.Pages.AdminPages
{
    public class AdminPodesavanjaNalogaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        public AdminPodesavanjaNalogaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Administrator Administrator { get; set; }

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

                Administrator = await _context.Administrator.FirstOrDefaultAsync(m => m.Id == id);

                if (Administrator == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
           /* Administrator stariAdmin= await _context.Administrator.FirstOrDefaultAsync(m => m.Id == Administrator.Id);
            if (Administrator.Ime==null)
            {
                Administrator.Ime = stariAdmin.Ime;
            }

            if (Administrator.Prezime == null)
            {
                Administrator.Prezime = stariAdmin.Prezime;
            }

            if (Administrator.Email == null)
            {
                Administrator.Email = stariAdmin.Email;
            }

            if (Administrator.Sifra == null)
            {
                Administrator.Sifra = stariAdmin.Sifra;
            }*/

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(Administrator.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AdminPocetna");
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrator.Any(e => e.Id == id);
        }
    }
}
