using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages.OrganizatorPages
{
    public class Organizator_LogOutModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public bool parse { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public Organizator_LogOutModel(WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
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

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                HttpContext.Session.Remove("idOrganizator");
            }
            return RedirectToPage("../Index");
        }
        public async Task<IActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                return RedirectToPage("../OrganizatorPages/OrganizatorPocetna");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
