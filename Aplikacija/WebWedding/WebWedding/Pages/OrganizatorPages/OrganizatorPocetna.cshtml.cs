using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages
{
    public class OrganizatorPocetnaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        public bool parse { get; set; }
        public OrganizatorPocetnaModel(WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int OrganizatorID { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Organizator organizator = await _db.Organizatori.FindAsync(idOrganizator);
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
