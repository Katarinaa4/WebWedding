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
    public class ListaNapomenaZaProstorModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public ListaNapomenaZaProstorModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        public ICollection<Napomena> listaNapomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public Prostor prostor { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                prostor = await _db.Prostori.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                listaNapomena = await _db.Napomene.Where(x => x.MojProstor == prostor).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostPovratakAsync(int idP, bool izmenjeno)
        {
            
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (izmenjeno)
                {
                    ID = idP;
                    var nap = await _db.Napomene.Include(x=>x.MojProstor).Where(x=>x.Id==idP).FirstOrDefaultAsync();
                    int id = nap.MojProstor.Id;
                    prostor = await _db.Prostori.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                    // string bla = prostor.Naziv;
                    listaNapomena = await _db.Napomene.Where(x => x.MojProstor == prostor).ToListAsync();
                    return Page();
                }
                else
                {
                    ID = idP;
                    prostor = await _db.Prostori.Include(x => x.ListaNapomena).Where(x => x.Id == idP).FirstOrDefaultAsync();
                    listaNapomena = await _db.Napomene.Where(x => x.MojProstor == prostor).ToListAsync();
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
