using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.OrganizatorPages
{
    public class PromeniBrojPlaneraModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public PromeniBrojPlaneraModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int broj { get; set; }

        [BindProperty]
        public Planer planer { get; set; }

        public bool parse { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                planer = await _db.Planeri.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIzmeniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var plan = await _db.Planeri.FindAsync(id);
                plan.BrojPlaneraNaRaspolaganju = broj;
                await _db.SaveChangesAsync();
                return RedirectToPage("../OrganizatorPages/Organizator_Planer_Prodavnica");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
