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
    public class KalendarDekoracijeModel : PageModel
    {
        private readonly WebWeddingContext _context;

        public bool parse { get; set; }

        [BindProperty]
        public int DekoracijaId { get; set; }
        [BindProperty]
        public int datumId { get; set; }
        [BindProperty]
        public string datumTip { get; set; }

        [BindProperty]
        public DateTime datumRez { get; set; }
        [BindProperty]
        public DateTime datumZak { get; set; }

        public List<SelectListItem> DekoracijeOptions { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }

        public KalendarDekoracijeModel(WebWeddingContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                DekoracijeOptions = _context.Dekoracije.Where(x => x.StatusPrikaza == "Prikaz").Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostDodajRezervisaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                DekoracijaRezervisani dr = new DekoracijaRezervisani();
                dr.datum = datumRez;
                Dekoracija d = _context.Dekoracije.Include(x => x.Rezervisani).FirstOrDefault(x => x.Id == DekoracijaId);
                if (d != null)
                {
                    dr.MojaDekoracija = d;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarDekoracije");
                }

                foreach (DekoracijaRezervisani drez in d.Rezervisani)
                {
                    if (drez.datum == datumRez)
                        return new RedirectToPageResult("./KalendarDekoracije");
                }

                _context.DekoracijaRezervisaniD.Add(dr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarDekoracije");
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostDodajZakazaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                DekoracijaZakazani dr = new DekoracijaZakazani();
                dr.datum = datumZak;
                Dekoracija d = _context.Dekoracije.Include(x => x.Zakazani).FirstOrDefault(x => x.Id == DekoracijaId);
                if (d != null)
                {
                    dr.MojaDekoracija = d;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarDekoracije");
                }

                foreach (DekoracijaZakazani dzak in d.Zakazani)
                {
                    if (dzak.datum == datumZak)
                        return new RedirectToPageResult("./KalendarDekoracije");
                }

                _context.DekoracijaZakazaniD.Add(dr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarDekoracije");
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
                    DekoracijaRezervisani dr = _context.DekoracijaRezervisaniD.Find(datumId);
                    if (dr != null)
                    {
                        _context.DekoracijaRezervisaniD.Remove(dr);
                        await _context.SaveChangesAsync();
                    }
                }

                if (datumTip == "zakazano")
                {
                    DekoracijaZakazani dr = _context.DekoracijaZakazaniD.Find(datumId);
                    if (dr != null)
                    {
                        _context.DekoracijaZakazaniD.Remove(dr);
                        await _context.SaveChangesAsync();
                    }
                }

                return new RedirectToPageResult("./KalendarDekoracije");
            }
            else return RedirectToPage("../Index");
        }
    }
}