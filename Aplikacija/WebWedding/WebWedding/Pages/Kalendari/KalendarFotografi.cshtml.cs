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
    public class KalendarFotografiModel : PageModel
    {
        private readonly WebWeddingContext _context;

        public bool parse { get; set; }

        [BindProperty]
        public int FotografId { get; set; }
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

        public List<SelectListItem> FotografOptions { get; set; }

        public KalendarFotografiModel(WebWeddingContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                FotografOptions = _context.Fotografi.Where(x => x.StatusPrikaza == "Prikaz").Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Ime+ " "+a.Prezime
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
                FotografRezervisani fr = new FotografRezervisani();
                fr.datum = datumRez;
                Fotograf f = _context.Fotografi.Include(x => x.Rezervisani).FirstOrDefault(x => x.Id == FotografId);
                if (f != null)
                {
                    fr.MojFotograf = f;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarFotografi");
                }

                foreach (FotografRezervisani frez in f.Rezervisani)
                {
                    if (frez.datum == datumRez)
                        return new RedirectToPageResult("./KalendarFotografi");
                }

                _context.FotografiRezervisaniD.Add(fr);
                await _context.SaveChangesAsync();
                return  RedirectToPage("./KalendarFotografi");
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostDodajZakazaniAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                FotografZakazani fr = new FotografZakazani();
                fr.datum = datumZak;
                Fotograf f = _context.Fotografi.Include(x => x.Zakazani).FirstOrDefault(x => x.Id == FotografId);
                if (f != null)
                {
                    fr.MojFotograf = f;
                }
                else
                {
                    return new RedirectToPageResult("./KalendarFotografi");
                }

                foreach (FotografZakazani fzak in f.Zakazani)
                {
                    if (fzak.datum == datumZak)
                        return new RedirectToPageResult("./KalendarFotografi");
                }

                _context.FotografiZakazaniD.Add(fr);
                await _context.SaveChangesAsync();
                return new RedirectToPageResult("./KalendarFotografi");
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
                    FotografRezervisani fr = _context.FotografiRezervisaniD.Find(datumId);
                    if (fr != null)
                    {
                        _context.FotografiRezervisaniD.Remove(fr);
                        await _context.SaveChangesAsync();
                    }
                }

                if (datumTip == "zakazano")
                {
                    FotografZakazani fr = _context.FotografiZakazaniD.Find(datumId);
                    if (fr != null)
                    {
                        _context.FotografiZakazaniD.Remove(fr);
                        await _context.SaveChangesAsync();
                    }
                }

                return new RedirectToPageResult("./KalendarFotografi");
            }
            else return RedirectToPage("../Index");
        }
    }
}