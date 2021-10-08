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
    public class KreirajZakazaniFotografModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }

        [BindProperty]
        public FotografZakazani novZakazani { get; set; }

        public KreirajZakazaniFotografModel(WebWeddingContext db)
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
                novZakazani.datum = DateTime.Now;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");

            }

        }

        public async Task<ActionResult> OnPostDodajAsync()
        {

            /* if (!ModelState.IsValid)
             {
                 return Page();
             }
             else
             {*/
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var pom = _db.FotografiZakazaniD.Include(x => x.MojFotograf).Where(x => x.MojFotograf.Id == ID && x.datum == novZakazani.datum).FirstOrDefault();
                if (pom != null)
                {

                    return Page();
                }
                else
                {
                    Fotograf mojFotograf = await _db.Fotografi.Where(x => x.Id == ID).FirstOrDefaultAsync();
                    novZakazani.MojFotograf = mojFotograf;
                    await _db.FotografiZakazaniD.AddAsync(novZakazani);
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
