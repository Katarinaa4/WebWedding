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
    public class KreirajNapomenuFotografModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public KreirajNapomenuFotografModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        [BindProperty]
        public Fotograf fotograf { get; set; }

        [BindProperty]
        public Napomena napomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }

        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                fotograf = await _db.Fotografi.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostDodajAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var foto = await _db.Fotografi.Where(x => x.Id == id).FirstOrDefaultAsync();
                napomena.DatumKreiranja = DateTime.Now;
                napomena.MojFotograf = foto;
                await _db.Napomene.AddAsync(napomena);
                await _db.SaveChangesAsync();
                return RedirectToPage("../OrganizatorPages/OrganizatorONama");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
