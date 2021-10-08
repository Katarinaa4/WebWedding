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
    public class PrikazMenija_OrganizatorModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public ICollection<Meni> listaMenija { get; set; }

        [BindProperty]
        public Prostor mojP { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public PrikazMenija_OrganizatorModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        
        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                mojP = await _db.Prostori.Where(x => x.Id == id).FirstOrDefaultAsync();
                Id = mojP.Id;
                ID = id;
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostNPAsync(int id, int idP)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                int iddd = ID;
                this.Id = idP;
                var zaBrisanje = await _db.Meniji.FindAsync(id);
                //ID = zaBrisanje.MojProstor.Id;
                // Prostor mojP = await _db.Prostori.Include(x=>x.Id).Where(x => x.Id == ID).FirstOrDefaultAsync();
                //int idd = zaBrisanje.MojProstor.Id;
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == idP).ToListAsync();
                zaBrisanje.Status = "NePrikazuj";
                await _db.SaveChangesAsync();
                //Response.Redirect("/OrganizatorPages/PrikazMenija_Organizator?id="+ID);
                // RedirectToRoute("/OrganizatorPages/PrikazMenija_Organizator.cshtml", new { id = idP });
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
