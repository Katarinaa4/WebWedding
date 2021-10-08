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
    public class KreirajZakazaniDekoracijaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }

        [BindProperty]
        public DekoracijaZakazani novZakazani { get; set; }

        public KreirajZakazaniDekoracijaModel(WebWeddingContext db)
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
                var pom = _db.DekoracijaZakazaniD.Include(x => x.MojaDekoracija).Where(x => x.MojaDekoracija.Id == ID && x.datum == novZakazani.datum).FirstOrDefault();
                if (pom != null)
                {

                    return Page();
                }
                else
                {
                    Dekoracija mojaDekoracija = await _db.Dekoracije.Where(x => x.Id == ID).FirstOrDefaultAsync();
                    novZakazani.MojaDekoracija = mojaDekoracija;
                    await _db.DekoracijaZakazaniD.AddAsync(novZakazani);
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