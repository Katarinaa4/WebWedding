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
    public class OrganizatorObrisiMeniModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public OrganizatorObrisiMeniModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        public bool pom { get; set; }

        [BindProperty]
        public ICollection<Zahtev> listaZahteva { get; set; }

        [BindProperty]
        public ICollection<Meni> listaMenija { get; set; }

        [BindProperty]
       public String Obavestenje { get; set; }

        [BindProperty]
        public Prostor mojP { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }



        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            OrganizatorID = idOrganizator;

            mojP = await _db.Prostori.Where(x => x.Id == id).FirstOrDefaultAsync();
            listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
            return Page();
        }

        public async Task<ActionResult> OnPostAsync(int id)
        {
            listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == id).ToListAsync();
            return Page();
        }

        public async Task<ActionResult> OnPostObrisiAsync(int id, int idP)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.Meniji.FindAsync(id);
                listaZahteva = await _db.Zahtevi.Include(x => x.MojMeni).ToListAsync();
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == idP).ToListAsync();
                pom = false;
                foreach(var zahtev in listaZahteva)
                {
                    if (zahtev.MojMeni != null)
                    {
                        if (zahtev.MojMeni.Id == zaBrisanje.Id)
                            pom = true;
                    }
                }
                if (!pom)
                {
                    zaBrisanje.Status = "Obrisan";
                    _db.Meniji.Remove(zaBrisanje);
                    await _db.SaveChangesAsync();
                    return Page();
                }
                else
                {
                    Obavestenje = "Nije moguce obrisati meni!";
                }
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostVratiAsync(int id, int idP)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                listaMenija = await _db.Meniji.Where(x => x.MojProstor.Id == idP).ToListAsync();
                var zaBrisanje = await _db.Meniji.FindAsync(id);
                zaBrisanje.Status = "Prikazi";
                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
