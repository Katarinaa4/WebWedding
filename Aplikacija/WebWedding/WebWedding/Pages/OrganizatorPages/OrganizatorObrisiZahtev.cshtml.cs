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
    public class OrganizatorObrisiZahtevModel : PageModel
    {

        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public Zahtev zahtev { get; set; }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public OrganizatorObrisiZahtevModel (WebWeddingContext db)
        {
            _db = db;
        }
        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                zahtev = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija)
                                        .FirstOrDefaultAsync(x => x.Id == id);
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }

            
            
        }

        public async Task<ActionResult> OnPostAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtev zaBrisanje = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija)
                                       .FirstOrDefaultAsync(x => x.Id == id);

                _db.Zahtevi.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage("./OrganizatorListaZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
