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
    public class Organizator_Planer_ProdavnicaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public Organizator_Planer_ProdavnicaModel(WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int OrganizatorID { get; set; }
        public ICollection<Planer> listaPlanera { get; set; }
        bool parse;

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            OrganizatorID = idOrganizator;
            listaPlanera = await _db.Planeri.ToListAsync();

            return Page();
        }
    }
}
