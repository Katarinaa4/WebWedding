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
    public class ListaNapomenaZaDekoracijuModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public ListaNapomenaZaDekoracijuModel(WebWeddingContext db)
        {
            _db = db;
        }

        public bool parse { get; set; }

        public ICollection<Napomena> listaNapomena { get; set; }

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public Dekoracija dekoracija { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                dekoracija = await _db.Dekoracije.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync();
                listaNapomena = await _db.Napomene.Where(x => x.MojaDekoracija == dekoracija).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostPovratakAsync(int idD, bool izmenjeno)
        {

            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (izmenjeno)
                {
                    ID = idD;
                    var nap = await _db.Napomene.Include(x => x.MojaDekoracija).Where(x => x.Id == idD).FirstOrDefaultAsync();
                    int id = nap.MojaDekoracija.Id;
                    dekoracija = await _db.Dekoracije.Include(x => x.ListaNapomena).Where(x => x.Id == id).FirstOrDefaultAsync(); ;
                    listaNapomena = await _db.Napomene.Where(x => x.MojaDekoracija == dekoracija).ToListAsync();
                    return Page();
                }
                else
                {
                    ID = idD;
                    dekoracija = await _db.Dekoracije.Include(x => x.ListaNapomena).Where(x => x.Id == idD).FirstOrDefaultAsync(); ;
                    listaNapomena = await _db.Napomene.Where(x => x.MojaDekoracija == dekoracija).ToListAsync();
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
