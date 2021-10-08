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

namespace WebWedding.Pages.AdminPages
{
    public class AdminDodajNarudzbinu : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;

        [BindProperty]
        public Narudzbina Narudzbina { get; set; }
        [BindProperty]
        public int PlanerId { get; set; }
        public List<SelectListItem> PlanerOptions { get; set; }
        public List<SelectListItem> KorisnikOptions { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public List<SelectListItem> StatusList { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        [BindProperty]
        public int KorisnikId { get; set; }
        public AdminDodajNarudzbinu(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                PlanerOptions = _context.Planeri.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                KorisnikOptions = _context.Korisnici.Where(x=>x.Arhivirano!=true).Select(a =>
                                                          new SelectListItem
                                                          {
                                                              Value = a.Id.ToString(),
                                                              Text = a.Ime+" "+a.Prezime
                                                          }).ToList();
                StatusList = new List<SelectListItem>();
                StatusList.Add(new SelectListItem("Naruceno", "Naruceno"));
                StatusList.Add(new SelectListItem("Poslato", "Poslato"));
                StatusList.Add(new SelectListItem("Isporuceno", "Isporuceno"));

                return Page();
            }
            else
            {
               return RedirectToPage("../Index");
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                
                Korisnik k = await _context.Korisnici.Where(x => x.Id==KorisnikId).FirstOrDefaultAsync();
                if (k != null) 
                {
                    Narudzbina.MojKorisnik = k;
                    Narudzbina.Email = k.Email;
                    Narudzbina.Ime = k.Ime;
                    Narudzbina.Prezime = k.Prezime;
                }
                else
                {
                    PlanerOptions = _context.Planeri.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                    KorisnikOptions = _context.Korisnici.Select(a =>
                                                          new SelectListItem
                                                          {
                                                              Value = a.Id.ToString(),
                                                              Text = a.Ime + " " + a.Prezime
                                                          }).ToList();
                    StatusList = new List<SelectListItem>();
                    StatusList.Add(new SelectListItem("Naruceno", "Naruceno"));
                    StatusList.Add(new SelectListItem("Poslato", "Poslato"));
                    StatusList.Add(new SelectListItem("Isporuceno", "Isporuceno"));
                    return Page();
                }

                Planer p = await _context.Planeri.Where(x => x.Id == PlanerId).FirstOrDefaultAsync();
                if (p != null)
                {
                    Narudzbina.MojPlaner = p;
                }
                else
                {
                    return new RedirectToPageResult("./AdminDodajNarudzbinu");
                }

                Narudzbina.Arhivirano = false;
                _context.Narudzbine.Add(Narudzbina);
                await _context.SaveChangesAsync();

                return RedirectToPage("./AdminPregledNarudzbina");
            }
            else return RedirectToPage("../Index");
        }
    }
}
