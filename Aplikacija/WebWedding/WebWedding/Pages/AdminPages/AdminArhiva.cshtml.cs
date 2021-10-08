using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebWedding.Pages.AdminPages
{
    public class AdminArhivaModel : PageModel
    {
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }
        public async Task<IActionResult> OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                return Page();
            }

            else return RedirectToPage("../Index");
        }
    }
}