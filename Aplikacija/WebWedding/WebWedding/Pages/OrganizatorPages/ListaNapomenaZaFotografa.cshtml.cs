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
    public class ListaNapomenaZaFotografaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public ListaNapomenaZaFotografaModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        public ICollection<Napomena> listaNapomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public Fotograf fotograf { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                fotograf = await _db.Fotografi.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                listaNapomena = await _db.Napomene.Where(x => x.MojFotograf == fotograf).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostPovratakAsync(int idF, bool izmenjeno)
        {

            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (izmenjeno)
                {
                    ID = idF;
                    var nap = await _db.Napomene.Include(x => x.MojFotograf).Where(x => x.Id == idF).FirstOrDefaultAsync();
                    int id = nap.MojFotograf.Id;
                    fotograf = await _db.Fotografi.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                    listaNapomena = await _db.Napomene.Where(x => x.MojFotograf == fotograf).ToListAsync();
                    return Page();
                }
                else
                {
                    ID = idF;
                    fotograf = await _db.Fotografi.Include(x => x.ListaNapomena).Where(x => x.Id == idF).FirstOrDefaultAsync();
                    listaNapomena = await _db.Napomene.Where(x => x.MojFotograf == fotograf).ToListAsync();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostUkloniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.Napomene.Where(x => x.Id == id).FirstOrDefaultAsync();
                _db.Napomene.Remove(zaBrisanje);
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
