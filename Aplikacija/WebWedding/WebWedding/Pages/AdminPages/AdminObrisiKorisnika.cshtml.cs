using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding
{
    public class AdminObrisiKorisnikaModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminObrisiKorisnikaModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Korisnik Korisnik { get; set; }

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

                Korisnik = await _context.Korisnici.FirstOrDefaultAsync(m => m.Id == id);
                //Korisnik = await _context.Korisnici.Include(x => x.MojZahtev).FirstOrDefaultAsync(m => m.Id == id);

                if (Korisnik == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else return RedirectToPage("../Index");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (id == null)
                {
                    return NotFound();
                }

                //Korisnik = await _context.Korisnici.FindAsync(id);
                Korisnik = await _context.Korisnici.Include(x => x.MojZahtev).Include(x=>x.Narudzbine).FirstOrDefaultAsync(m => m.Id == id);

                if (Korisnik != null)
                {
                    if(Korisnik.MojZahtev!=null)
                    {
                        _context.Zahtevi.Remove(Korisnik.MojZahtev);
                    }
                    if(Korisnik.Narudzbine.Count!=0)
                    {
                        foreach (Narudzbina n in Korisnik.Narudzbine)
                            _context.Narudzbine.Remove(n);
                    }
                    _context.Korisnici.Remove(Korisnik);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledArhiviranihKorisnika");
            }
            else return RedirectToPage("../Index");
        }
    }
}