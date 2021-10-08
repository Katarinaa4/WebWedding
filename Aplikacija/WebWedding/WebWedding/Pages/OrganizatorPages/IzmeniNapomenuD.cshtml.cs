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
    public class IzmeniNapomenuDModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public IzmeniNapomenuDModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        [BindProperty]
        public Napomena napomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public string novSadrzaj { get; set; }

        public bool izmenjeno { get; set; }

        [BindProperty]
        public Dekoracija dekoracija { get; set; }

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
        public async Task<ActionResult> OnPostAsync(int id, int idD)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {

                OrganizatorID = idOrganizator;
                ID = id;
                dekoracija = await _db.Dekoracije.Where(x => x.Id == idD).FirstOrDefaultAsync();
                napomena = await _db.Napomene.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                return RedirectToPage("../OrganizatorPages/ListaNapomenaZaDekoraciju");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostSacuvajAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                izmenjeno = true;
                var nap = await _db.Napomene.Where(x => x.Id == id).FirstOrDefaultAsync();
                nap.DatumKreiranja = DateTime.Now;
                nap.SadrzajNapomene = novSadrzaj;
                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
