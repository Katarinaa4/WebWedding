using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWedding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WebWedding.Pages.OrganizatorPages
{
    public class KreirajRezervisaniMuzikaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public MuzikaRezervisani novRezervisani { get; set; }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }

        public KreirajRezervisaniMuzikaModel(WebWeddingContext db)
        {
            _db = db;
        }

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
                novRezervisani.datum = DateTime.Now;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostDodajAsync()
        {

            /*if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {*/
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var pom = _db.MuzikaRezervisaniD.Include(x => x.MojaMuzika).Where(x => x.MojaMuzika.Id == ID && x.datum == novRezervisani.datum).FirstOrDefault();
                if (pom != null)
                {

                    return Page();
                }
                else
                {
                    Muzika mojaMuzika = await _db.Muzika.Where(x => x.Id == ID).FirstOrDefaultAsync();
                    novRezervisani.MojaMuzika = mojaMuzika;
                    await _db.MuzikaRezervisaniD.AddAsync(novRezervisani);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("./OrganizatorONama");
                }
           }
            else
            {
                return RedirectToPage("../Index");

            }
        }

    }
}
