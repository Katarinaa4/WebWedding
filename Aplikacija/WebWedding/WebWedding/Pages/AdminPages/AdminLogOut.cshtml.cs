using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding.Pages.AdminPages
{
    public class AdminLogOutModel : PageModel
    {
        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminLogOutModel(WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                Administrator admin = await _db.Administrator.FindAsync(idAdmin);

                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
               HttpContext.Session.Remove("idAdmin");
            }
            return RedirectToPage("../Index");
        }
        public async Task<IActionResult> OnPostNazadAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                return RedirectToPage("../AdminPages/AdminPocetna");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}