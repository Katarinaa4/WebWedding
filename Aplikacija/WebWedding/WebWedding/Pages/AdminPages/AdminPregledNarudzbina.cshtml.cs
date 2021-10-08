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
    public class AdminPregledNarudzbinaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminPregledNarudzbinaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public IList<Narudzbina> Narudzbina { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                Narudzbina = await _context.Narudzbine.Include(x => x.MojPlaner).Where(x => x.Arhivirano == false || x.Arhivirano==null).ToListAsync();
                return Page();
            }
            else return RedirectToPage("../Index");
        }
    }
}
