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
    public class AdminObrisiZahtevModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        public AdminObrisiZahtevModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zahtev Zahtev { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

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

                Zahtev = await _context.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                    .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                    .Include(x => x.MojaMuzika)
                    .Include(x => x.MojaDekoracija).FirstOrDefaultAsync(m => m.Id == id);

                if (Zahtev == null)
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

                Zahtev = await _context.Zahtevi.FindAsync(id);              

                if (Zahtev != null)
                {
                    //sada treba da obrisemo sve zakazane/rezervisane datume, jer kada brisemo zahtev
                    //ti datumi sada postaju slobodni

                    #region Obrisi datum Prostor
                    if (Zahtev.PotvrdjenoProstor==true)
                    {
                        ProstorZakazani dat = await _context.ZakazaniDatumi.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.ZakazaniDatumi.Remove(dat);
                        }
                    }
                    else if (Zahtev.PotvrdjenoProstor == false)
                    {
                        ProstorRezervisani dat = await _context.RezervisaniDatumi.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.RezervisaniDatumi.Remove(dat);
                        }
                    }
                    #endregion

                    #region Obrisi datum Dekoracija
                    if (Zahtev.PotvrdjenoDekoracija==true)
                    {
                        DekoracijaZakazani dat = await _context.DekoracijaZakazaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.DekoracijaZakazaniD.Remove(dat);
                        }
                    }
                    else if (Zahtev.PotvrdjenoDekoracija == false)
                    {
                        DekoracijaRezervisani dat = await _context.DekoracijaRezervisaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.DekoracijaRezervisaniD.Remove(dat);
                        }
                    }
                    #endregion

                    #region Obrisi datum Muzika
                    if (Zahtev.PotvrdjenoMuzika==true)
                    {
                        MuzikaZakazani dat = await _context.MuzikaZakazaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.MuzikaZakazaniD.Remove(dat);
                        }
                    }
                    else if (Zahtev.PotvrdjenoMuzika == false)
                    {
                        MuzikaRezervisani dat = await _context.MuzikaRezervisaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.MuzikaRezervisaniD.Remove(dat);
                        }
                    }
                    #endregion

                    #region Obrisi datum Fotograf
                    if (Zahtev.PotvrdjenoFotograf==true)
                    {
                        FotografZakazani dat = await _context.FotografiZakazaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.FotografiZakazaniD.Remove(dat);
                        }
                    }
                    else if (Zahtev.PotvrdjenoFotograf == false)
                    {
                        FotografRezervisani dat = await _context.FotografiRezervisaniD.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.FotografiRezervisaniD.Remove(dat);
                        }
                    }
                    #endregion

                    _context.Zahtevi.Remove(Zahtev);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AdminPregledArhiviranihZahteva");
            }
            else return RedirectToPage("../Index");
        }
    }
}