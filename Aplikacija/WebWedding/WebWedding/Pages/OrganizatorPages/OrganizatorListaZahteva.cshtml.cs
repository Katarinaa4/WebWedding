using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages
{
    public class OrganizatorListaZahtevaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }

        public OrganizatorListaZahtevaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public IList<Zahtev> zahtevi { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostObrisiZahtevAsych(int id)
        {

            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtev zaBrisanje = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija)
                                       .FirstOrDefaultAsync(x => x.Id == id);

                if (zaBrisanje != null)
                {
                    _db.Zahtevi.Remove(zaBrisanje);
                    await _db.SaveChangesAsync();
                }
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }


    }
}
