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
    public class ListaNapomenaZaMuzikuModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public ListaNapomenaZaMuzikuModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        public ICollection<Napomena> listaNapomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public Muzika muzika { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                muzika = await _db.Muzika.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                listaNapomena = await _db.Napomene.Where(x => x.MojaMuzika == muzika).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostPovratakAsync(int idM, bool izmenjeno)
        {

            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (izmenjeno)
                {
                    ID = idM;
                    var nap = await _db.Napomene.Include(x => x.MojaMuzika).Where(x => x.Id == idM).FirstOrDefaultAsync();
                    int id = nap.MojaMuzika.Id;
                    muzika = await _db.Muzika.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                    listaNapomena = await _db.Napomene.Where(x => x.MojaMuzika == muzika).ToListAsync();
                    return Page();
                }
                else
                {
                    ID = idM;
                    muzika = await _db.Muzika.Include(x => x.ListaNapomena).Where(x => x.Id == idM).FirstOrDefaultAsync();
                    listaNapomena = await _db.Napomene.Where(x => x.MojaMuzika == muzika).ToListAsync();
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
