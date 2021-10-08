using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWedding;
using WebWedding.Models;

namespace WebWedding.Pages.Kalendari
{
    public class KalendarProstoriModel : PageModel
    {
        private readonly WebWeddingContext _context;

        public bool parse { get; set; }

        [BindProperty]
        public int ProstorId { get; set; }
        [BindProperty]
        public int datumId { get; set; }
        [BindProperty]
        public string datumTip { get; set; }

        [BindProperty]
        public DateTime datumRez { get; set; }
        [BindProperty]
        public DateTime datumZak { get; set; }

        public List<SelectListItem> ProstorOptions { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }

        public KalendarProstoriModel(WebWeddingContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ProstorOptions = _context.Prostori.Where(x=>x.StatusPrikaza=="Prikaz").Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostDodajRezervisaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ProstorRezervisani pr = new ProstorRezervisani();
                pr.datum = datumRez;            
                Prostor p = _context.Prostori.Include(x => x.Rezervisani).FirstOrDefault(x => x.Id == ProstorId);
                if (p != null)
                {
                    pr.MojProstor = p;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarProstori");
                }

                foreach(ProstorRezervisani prez in p.Rezervisani)
                {
                    if(prez.datum==datumRez)
                        return new RedirectToPageResult("./KalendarProstori");
                }

                _context.RezervisaniDatumi.Add(pr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarProstori");
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostDodajZakazaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ProstorZakazani pr = new ProstorZakazani();
                pr.datum = datumZak;
                Prostor p = _context.Prostori.Include(x => x.Zakazani).FirstOrDefault(x => x.Id == ProstorId);
                if (p != null)
                {
                    pr.MojProstor = p;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarProstori");
                }

                foreach (ProstorZakazani pzak in p.Zakazani)
                {
                    if (pzak.datum == datumZak)
                        return new RedirectToPageResult("./KalendarProstori");
                }
                _context.ZakazaniDatumi.Add(pr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarProstori");
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostObrisiDatumAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (datumTip == "rezervisano")
                {
                    ProstorRezervisani pr = _context.RezervisaniDatumi.Find(datumId);
                    if (pr != null)
                    {
                        _context.RezervisaniDatumi.Remove(pr);
                        await _context.SaveChangesAsync();
                    }
                }

                if (datumTip == "zakazano")
                {
                    ProstorZakazani pr = _context.ZakazaniDatumi.Find(datumId);
                    if (pr != null)
                    {
                        _context.ZakazaniDatumi.Remove(pr);
                        await _context.SaveChangesAsync();
                    }
                }

                return new RedirectToPageResult("./KalendarProstori");
            }
            else return RedirectToPage("../Index");
        }
    }
}