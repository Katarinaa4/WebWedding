using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWedding.Models;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages
{
    public class OrganizatorGalerijaModel : PageModel
    {
        [BindProperty]
        public IList<Slika> mojeSlike { get; set; }

        public bool parse { get; set; }

        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public OrganizatorGalerijaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                mojeSlike = await _db.Slike.ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");

            }
        }
    }
}
