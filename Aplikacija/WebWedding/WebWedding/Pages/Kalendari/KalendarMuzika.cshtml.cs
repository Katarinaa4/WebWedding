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
    public class KalendarMuzikaModel : PageModel
    {
        private readonly WebWeddingContext _context;

        public bool parse { get; set; }

        [BindProperty]
        public int MuzikaId { get; set; }
        [BindProperty]
        public int datumId { get; set; }
        [BindProperty]
        public string datumTip { get; set; }

        [BindProperty]
        public DateTime datumRez { get; set; }
        [BindProperty]
        public DateTime datumZak { get; set; }

        [BindProperty]
        public int OrganizatorID { get; set; }

        public List<SelectListItem> MuzikaOptions { get; set; }

        public KalendarMuzikaModel(WebWeddingContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                MuzikaOptions = _context.Muzika.Where(x => x.StatusPrikaza == "Prikaz").Select(a =>
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
                MuzikaRezervisani mr = new MuzikaRezervisani();
                mr.datum = datumRez;
                Muzika m = _context.Muzika.Include(x => x.Rezervisani).FirstOrDefault(x => x.Id == MuzikaId);
                if (m != null)
                {
                    mr.MojaMuzika = m;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarMuzika");
                }

                foreach (MuzikaRezervisani mrez in m.Rezervisani)
                {
                    if (mrez.datum == datumRez)
                        return new RedirectToPageResult("./KalendarMuzika");
                }

                _context.MuzikaRezervisaniD.Add(mr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarMuzika");
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostDodajZakazaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                MuzikaZakazani mr = new MuzikaZakazani();
                mr.datum = datumZak;
                Muzika m = _context.Muzika.Include(x => x.Zakazani).FirstOrDefault(x => x.Id == MuzikaId);
                if (m != null)
                {
                    mr.MojaMuzika = m;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarMuzika");
                }

                foreach (MuzikaZakazani mzak in m.Zakazani)
                {
                    if (mzak.datum == datumZak)
                        return new RedirectToPageResult("./KalendarMuzika");
                }

                _context.MuzikaZakazaniD.Add(mr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarMuzika");
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
                    MuzikaRezervisani mr = _context.MuzikaRezervisaniD.Find(datumId);
                    if (mr != null)
                    {
                        _context.MuzikaRezervisaniD.Remove(mr);
                        await _context.SaveChangesAsync();
                    }
                }

                if (datumTip == "zakazano")
                {
                    MuzikaZakazani pr = _context.MuzikaZakazaniD.Find(datumId);
                    if (pr != null)
                    {
                        _context.MuzikaZakazaniD.Remove(pr);
                        await _context.SaveChangesAsync();
                    }
                }

                return new RedirectToPageResult("./KalendarMuzika");
            }
            else return RedirectToPage("../Index");
        }
    }
}