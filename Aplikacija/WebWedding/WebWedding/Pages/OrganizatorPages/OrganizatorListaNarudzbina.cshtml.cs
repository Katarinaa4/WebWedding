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
    public class OrganizatorListaNarudzbinaModel : PageModel
    {
       public WebWeddingContext _db { get; set; }

        public OrganizatorListaNarudzbinaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public ICollection<Narudzbina> listaN { get; set; }

        public bool parse { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                listaN = await _db.Narudzbine.Include(x => x.MojPlaner).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostPoslatoAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var narudzbina = await _db.Narudzbine.FindAsync(id);
                narudzbina.Status = "Poslato";
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIsporucenoAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var narudzbina = await _db.Narudzbine.FindAsync(id);
                narudzbina.Status = "Isporuceno";
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
