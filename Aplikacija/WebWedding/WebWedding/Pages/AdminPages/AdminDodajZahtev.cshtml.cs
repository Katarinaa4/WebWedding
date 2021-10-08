using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding
{
    public class AdminDodajZahtevModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        public List<SelectListItem> KorisnikOptions { get; set; }
        [BindProperty]
        public int KorisnikId { get; set; }
        public List<SelectListItem> FotografOptions { get; set; }
        [BindProperty]
        public int FotografId { get; set; }
        public List<SelectListItem> ProstorOptions { get; set; }
        [BindProperty]
        public int ProstorId { get; set; }
        public List<SelectListItem> MeniOptions { get; set; }
        [BindProperty]
        public int MeniId { get; set; }
        public List<SelectListItem> DekoracijaOptions { get; set; }
        [BindProperty]
        public int DekoracijaId { get; set; }
        [BindProperty]
        public int MuzikaId { get; set; }
        public List<SelectListItem> MuzikaOptions { get; set; }
        [BindProperty]
        public List<SelectListItem> TrueFalseList { get; set; }
      
        [BindProperty]
        public List<SelectListItem> StatusList { get; set; }
        [BindProperty]
        public List<SelectListItem> PoslatoList { get; set; }
        [BindProperty]
        public int AdminID { get; set; }

        public AdminDodajZahtevModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }

        /*public IActionResult OnGet()
        {

            return Page();
        }*/
        public void  OnGet()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                AdminID = idAdmin;
                LoadListItems();
                
            }
          
        }

        [BindProperty]
        public Zahtev Zahtev { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            /* if (!KorisnikId.Equals(null))
             {
                 Korisnik Korisnik = await _context.Korisnici.FindAsync(KorisnikId);
                 Zahtev.MojKorisnik = Korisnik;
             }*/
            parse = int.TryParse(HttpContext.Session.GetString("idAdmin"), out int idAdmin);
            if (parse)
            {
                if (!ModelState.IsValid)
                {
                    LoadListItems();
                    return Page();
                    
                }

                Korisnik Korisnik = await _context.Korisnici.FindAsync(KorisnikId);
                Zahtev.MojKorisnik = Korisnik;

                Prostor Prostor = _context.Prostori.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == ProstorId).FirstOrDefault();               
                Zahtev.MojProstor = Prostor;
                
                //dodavanje datuma kao zakazani/rezervisani
                if (Zahtev.PotvrdjenoProstor==true)
                {
                    ProstorZakazani pz = new ProstorZakazani();
                    pz.datum = Zahtev.IzabraniDatum;
                    pz.MojProstor = Zahtev.MojProstor;
                    Zahtev.MojProstor.Zakazani.Add(pz);
                }
                else if (Zahtev.PotvrdjenoProstor == false)
                {
                    ProstorRezervisani pr = new ProstorRezervisani();
                    pr.datum = Zahtev.IzabraniDatum;
                    pr.MojProstor = Zahtev.MojProstor;
                    Zahtev.MojProstor.Rezervisani.Add(pr);
                }


                Meni Meni = _context.Meniji.Where(x => x.Id == MeniId).Include(x => x.MojProstor).ToList().ElementAt(0);
                //FindAsync(MeniId);
                if (Meni.MojProstor.Id == ProstorId)
                {
                    Zahtev.MojMeni = Meni;
                }
                else
                {
                    return RedirectToPage("./AdminDodajZahtev");
                }

                Fotograf Fotograf = await _context.Fotografi.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == FotografId).FirstAsync();
                Zahtev.MojFotograf = Fotograf;

                //dodavanje datuma kao zakazani/rezervisani
                if (Zahtev.PotvrdjenoFotograf==true)
                {
                    FotografZakazani fz = new FotografZakazani();
                    fz.datum = Zahtev.IzabraniDatum;
                    fz.MojFotograf = Zahtev.MojFotograf;
                    Zahtev.MojFotograf.Zakazani.Add(fz);
                }
                else if (Zahtev.PotvrdjenoFotograf == false)
                {
                    FotografRezervisani fr = new FotografRezervisani();
                    fr.datum = Zahtev.IzabraniDatum;
                    fr.MojFotograf = Zahtev.MojFotograf;
                    Zahtev.MojFotograf.Rezervisani.Add(fr);
                }

                Dekoracija Dekoracija = await _context.Dekoracije.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == DekoracijaId).FirstAsync();
                Zahtev.MojaDekoracija = Dekoracija;

                if (Zahtev.PotvrdjenoDekoracija==true)
                {
                    DekoracijaZakazani dz = new DekoracijaZakazani();
                    dz.datum = Zahtev.IzabraniDatum;
                    dz.MojaDekoracija = Zahtev.MojaDekoracija;
                    Zahtev.MojaDekoracija.Zakazani.Add(dz);
                }
                else if (Zahtev.PotvrdjenoDekoracija == false)
                {
                    DekoracijaRezervisani dr = new DekoracijaRezervisani();
                    dr.datum = Zahtev.IzabraniDatum;
                    dr.MojaDekoracija = Zahtev.MojaDekoracija;
                    Zahtev.MojaDekoracija.Rezervisani.Add(dr);
                }

                Muzika Muzika = await _context.Muzika.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == MuzikaId).FirstAsync();
                Zahtev.MojaMuzika = Muzika;

                if (Zahtev.PotvrdjenoMuzika==true)
                {
                    MuzikaZakazani mz = new MuzikaZakazani();
                    mz.datum = Zahtev.IzabraniDatum;
                    mz.MojaMuzika = Zahtev.MojaMuzika;
                    Zahtev.MojaMuzika.Zakazani.Add(mz);
                }
                else if (Zahtev.PotvrdjenoMuzika == false)
                {
                    MuzikaRezervisani mr = new MuzikaRezervisani();
                    mr.datum = Zahtev.IzabraniDatum;
                    mr.MojaMuzika = Zahtev.MojaMuzika;
                    Zahtev.MojaMuzika.Rezervisani.Add(mr);
                }

                Korisnik.MojZahtev = Zahtev;
                Zahtev.Arhivirano = false;

                _context.Zahtevi.Add(Zahtev);
                await _context.SaveChangesAsync();

                return RedirectToPage("./AdminPregledZahteva");
            }

            else return RedirectToPage("../Index");
        }

        //pomocna funkcija koja ucitava sve potrebne vrednosti za select liste
        public void LoadListItems()
        {
            //samo oni korisnici koji nemaju zahtev mogu da naprave zahtev
            KorisnikOptions = _context.Korisnici.Where(x => x.MojZahtev == null && x.Arhivirano!=true).Select(a =>
                                                            new SelectListItem
                                                            {
                                                                Value = a.Id.ToString(),
                                                                Text = a.Ime + " " + a.Prezime
                                                            }).ToList();

            ProstorOptions = _context.Prostori.Select(a =>
                                                     new SelectListItem
                                                     {
                                                         Value = a.Id.ToString(),
                                                         Text = a.Naziv
                                                     }).ToList();
            FotografOptions = _context.Fotografi.Select(a =>
                                                     new SelectListItem
                                                     {
                                                         Value = a.Id.ToString(),
                                                         Text = a.Ime + " " + a.Prezime
                                                     }).ToList();

            /*MeniOptions = _context.Meniji.Include(x => x.MojProstor).OrderBy(x => x.MojProstor.Id).Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv + ": restoran " + a.MojProstor.Naziv
                                                         }).ToList();*/
            DekoracijaOptions = _context.Dekoracije.Select(a =>
                                                     new SelectListItem
                                                     {
                                                         Value = a.Id.ToString(),
                                                         Text = a.Naziv
                                                     }).ToList();
            MuzikaOptions = _context.Muzika.Select(a =>
                                                     new SelectListItem
                                                     {
                                                         Value = a.Id.ToString(),
                                                         Text = a.Naziv
                                                     }).ToList();

            TrueFalseList = new List<SelectListItem>();
            TrueFalseList.Add(new SelectListItem("Potvrdjeno", "true"));
            TrueFalseList.Add(new SelectListItem("Nepotvrdjeno", "false"));

            StatusList = new List<SelectListItem>();
            StatusList.Add(new SelectListItem("Odobren", "Odobren"));
            StatusList.Add(new SelectListItem("Odbijen", "Odbijen"));

            PoslatoList = new List<SelectListItem>();
            PoslatoList.Add(new SelectListItem("Poslato", "true"));
            PoslatoList.Add(new SelectListItem("Nije poslato", "false"));
        }
    
    }
}