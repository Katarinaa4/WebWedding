using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.AdminPages
{
    public class AdminPregledArhiviranihNarudzbinaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }

        public AdminPregledArhiviranihNarudzbinaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public IList<Narudzbina> Narudzbina { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                Narudzbina = await _context.Narudzbine.Include(x => x.MojPlaner).Where(x=>x.Arhivirano==true).ToListAsync();
                return Page();
            }
            else return RedirectToPage("../Index");
        }
    }
}