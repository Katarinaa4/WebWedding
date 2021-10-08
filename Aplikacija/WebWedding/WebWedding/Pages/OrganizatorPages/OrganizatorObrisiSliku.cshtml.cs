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
    public class OrganizatorObrisiSlikuModel : PageModel
    {
        [BindProperty]
        public Slika Slika { get; set; }

        public bool parse { get; set; }

        public WebWeddingContext _db { get; set; }

        public OrganizatorObrisiSlikuModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }
        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                Slika = await _db.Slike.FindAsync(id);
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Slika slikaZaBrisanje = await _db.Slike.FindAsync(ID);
                _db.Slike.Remove(slikaZaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage("./OrganizatorGalerija");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
