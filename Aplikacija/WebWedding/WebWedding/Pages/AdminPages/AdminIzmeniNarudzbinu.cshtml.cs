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
    public class AdminIzmeniNarudzbinuModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        [BindProperty]
        public int PlanerId { get; set; }
        public List<SelectListItem> PlanerOptions { get; set; }
        public bool parse { get; set; }
        [BindProperty]
        public List<SelectListItem> StatusList { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        [BindProperty]
        public List<SelectListItem> KorisnikOptions { get; set; }

        [BindProperty]
        public int KorisnikId { get; set; }

        public AdminIzmeniNarudzbinuModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Narudzbina Narudzbina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                if (id == null)
                {
                    return NotFound();
                }
                PlanerOptions = _context.Planeri.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
           
                StatusList = new List<SelectListItem>();
                StatusList.Add(new SelectListItem("Naruceno", "Naruceno"));
                StatusList.Add(new SelectListItem("Poslato", "Poslato"));
                StatusList.Add(new SelectListItem("Isporuceno", "Isporuceno"));

                KorisnikOptions = _context.Korisnici.Select(a =>
                                                            new SelectListItem
                                                            {
                                                                Value = a.Id.ToString(),
                                                                Text = a.Ime + " " + a.Prezime
                                                            }).ToList();

                Narudzbina = await _context.Narudzbine.Include(x=>x.MojPlaner).Include(x=>x.MojKorisnik).FirstOrDefaultAsync(m => m.Id == id);
                KorisnikId = Narudzbina.MojKorisnik.Id;
                PlanerId = Narudzbina.MojPlaner.Id;

                if (Narudzbina == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                Korisnik k = await _context.Korisnici.Where(x => x.Id == KorisnikId).FirstOrDefaultAsync();
                Planer p = await _context.Planeri.FindAsync(PlanerId);

                Narudzbina.Ime = k.Ime;
                Narudzbina.Prezime = k.Prezime;
                Narudzbina.Email = k.Email;
                Narudzbina.MojKorisnik = k;

                Narudzbina.MojPlaner = p;

                _context.Attach(Narudzbina).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarudzbinaExists(Narudzbina.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToPage("./AdminPregledNarudzbina");
            }

            else return RedirectToPage("../Index");
        }

        private bool NarudzbinaExists(int id)
        {
            return _context.Narudzbine.Any(e => e.Id == id);
        }
    }
}
