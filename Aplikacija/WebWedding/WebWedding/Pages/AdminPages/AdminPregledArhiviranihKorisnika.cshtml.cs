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
    public class AdminPregledArhiviranihKorisnikaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }
        public AdminPregledArhiviranihKorisnikaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public IList<Korisnik> Korisnici { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                Korisnici = await _context.Korisnici.Include(x => x.MojZahtev).Where(x => x.Arhivirano == true).ToListAsync();
                return Page();
            }
            else return RedirectToPage("../Index");
        }
    }
}