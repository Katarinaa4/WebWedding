using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;

namespace WebWedding
{
    public class AdminIzmeniZahtevModel : PageModel
    {
        private readonly WebWedding.WebWeddingContext _context;
        public bool parse { get; set; }
        public AdminIzmeniZahtevModel(WebWedding.WebWeddingContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Zahtev Zahtev { get; set; }
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
        public List<SelectListItem> MuzikaOptions { get; set; }
        [BindProperty]
        public int MuzikaId { get; set; }

        public IList<Zahtev> Zahtevi { get; set; }
        [BindProperty]
        public List<SelectListItem> TrueFalseList { get; set; }

        [BindProperty]
        public List<SelectListItem> StatusList { get; set; }

        [BindProperty]
        public List<SelectListItem> PoslatoList { get; set; }
        [BindProperty]
        public int AdminID { get; set; }


        //ova OnGetAsync preuzima Zahtev iz baze, zajedno sa svim referencama
        //na ostale elemente - prostor,muzika itd.
        //zatim inicijalizuje Select Liste koje se koriste za unos
        //podataka na formi, a onda postavlja default izabrano
        //ono sto se vec nalazi u Zahtevu -pocetno stanje zahteva
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
                if(Zahtev!=null)
                { 
                LoadSelectListItems();
                  //  if (Zahtev != null)
                  //  {
                        if (Zahtev.MojKorisnik != null)
                            KorisnikId = Zahtev.MojKorisnik.Id;
                    KorisnikOptions = _context.Korisnici.Where(x => x.Arhivirano != true && (x.MojZahtev == null || x.MojZahtev.Id == Zahtev.Id)).Select(a =>
                                                           new SelectListItem
                                                           {
                                                               Value = a.Id.ToString(),
                                                               Text = a.Ime + " " + a.Prezime
                                                           }).ToList();
                    //    if (Zahtev.MojProstor != null)
                    //        ProstorId = Zahtev.MojProstor.Id;
                    //    ProstorOptions = _context.Prostori.Select(a =>
                    //                                             new SelectListItem
                    //                                             {
                    //                                                 Value = a.Id.ToString(),
                    //                                                 Text = a.Naziv
                    //                                             }).ToList();
                    //    if (Zahtev.MojFotograf != null)
                    //        FotografId = Zahtev.MojFotograf.Id;
                    //    FotografOptions = _context.Fotografi.Select(a =>
                    //                                             new SelectListItem
                    //                                             {
                    //                                                 Value = a.Id.ToString(),
                    //                                                 Text = a.Ime + " " + a.Prezime
                    //                                             }).ToList();
                    //    //ne zaboravi za menije da pogledas kako da za opcije ima samo menije iz izabranog restorana
                    //    if (Zahtev.MojMeni != null)
                    //        MeniId = Zahtev.MojMeni.Id;
                    //    MeniOptions = _context.Meniji.Include(x => x.MojProstor).OrderBy(x => x.MojProstor.Id).Select(a =>
                    //                                             new SelectListItem
                    //                                             {
                    //                                                 Value = a.Id.ToString(),
                    //                                                 Text = a.Naziv + ": restoran " + a.MojProstor.Naziv
                    //                                             }).ToList();
                    //    if (Zahtev.MojaDekoracija != null)
                    //        DekoracijaId = Zahtev.MojaDekoracija.Id;
                    //    DekoracijaOptions = _context.Dekoracije.Select(a =>
                    //                                             new SelectListItem
                    //                                             {
                    //                                                 Value = a.Id.ToString(),
                    //                                                 Text = a.Naziv
                    //                                             }).ToList();
                    //    if (Zahtev.MojaMuzika != null)
                    //        MuzikaId = Zahtev.MojaMuzika.Id;
                    //    MuzikaOptions = _context.Muzika.Select(a =>
                    //                                             new SelectListItem
                    //                                             {
                    //                                                 Value = a.Id.ToString(),
                    //                                                 Text = a.Naziv
                    //                                             }).ToList();

                    //    TrueFalseList = new List<SelectListItem>();
                    //    TrueFalseList.Add(new SelectListItem("Potvrdjeno", "true"));
                    //    TrueFalseList.Add(new SelectListItem("Nepotvrdjeno", "false"));

                    //    StatusList = new List<SelectListItem>();
                    //    StatusList.Add(new SelectListItem("Odobren", "Odobren"));
                    //    StatusList.Add(new SelectListItem("Odbijen", "Odbijen"));

                    //    PoslatoList = new List<SelectListItem>();
                    //    PoslatoList.Add(new SelectListItem("Poslato", "true"));
                    //    PoslatoList.Add(new SelectListItem("Nije poslato", "false"));


                    #region Obrisi datum Prostor
                    if (Zahtev.PotvrdjenoProstor==true)
                    {
                        ProstorZakazani dat = await _context.ZakazaniDatumi.Where(x => x.datum == Zahtev.IzabraniDatum).FirstOrDefaultAsync();
                        if (dat != null)
                        {
                            _context.ZakazaniDatumi.Remove(dat);
                        }
                    }
                    else if(Zahtev.PotvrdjenoProstor ==false)
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

                    await _context.SaveChangesAsync();

                }

                if (Zahtev == null)
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
                if (!ModelState.IsValid)
                {
                    LoadSelectListItems();
                    return Page();
                }


                //sve se preuzima iz baze i postavljaju se kao novi, izmenjeni parametri
                Korisnik Korisnik = await _context.Korisnici.FindAsync(KorisnikId);
                Zahtev.MojKorisnik = Korisnik;

                Prostor Prostor = _context.Prostori.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == ProstorId).FirstOrDefault();
                Zahtev.MojProstor = Prostor;

                //novi, izmenjeni datumi se postavljaju u bazu
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
                    return  RedirectToPage("./AdminIzmeniZahtev",new { id = Zahtev.Id });
                }
                Zahtev.MojMeni = Meni;

                Fotograf Fotograf = await _context.Fotografi.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == FotografId).FirstAsync();
                Zahtev.MojFotograf = Fotograf;

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

                _context.Attach(Zahtev).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtevExists(Zahtev.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./AdminPregledZahteva");
            }
            else return RedirectToPage("../Index");
        }

        private bool ZahtevExists(int id)
        {
            return _context.Zahtevi.Any(e => e.Id == id);
        }

        public void ProstorPromenjen()
        {
            MeniId = Zahtev.MojMeni.Id;
            MeniOptions = _context.Meniji.Where(x=>x.MojProstor.Id==ProstorId).Select(a =>
                                                     new SelectListItem
                                                     {
                                                         Value = a.Id.ToString(),
                                                         Text = a.Naziv
                                                     }).ToList();
        }

        public void LoadSelectListItems()
        {


            if (Zahtev != null)
            {
                if (Zahtev.MojKorisnik != null)
                    KorisnikId = Zahtev.MojKorisnik.Id;
                KorisnikOptions = _context.Korisnici.Where(x=>x.Arhivirano!=true && (x.MojZahtev==null || x.MojZahtev.Id==Zahtev.Id)).Select(a =>
                                                       new SelectListItem
                                                       {
                                                           Value = a.Id.ToString(),
                                                           Text = a.Ime + " " + a.Prezime
                                                       }).ToList();
                if (Zahtev.MojProstor != null)
                    ProstorId = Zahtev.MojProstor.Id;
                ProstorOptions = _context.Prostori.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                if (Zahtev.MojFotograf != null)
                    FotografId = Zahtev.MojFotograf.Id;
                FotografOptions = _context.Fotografi.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Ime + " " + a.Prezime
                                                         }).ToList();
                //ne zaboravi za menije da pogledas kako da za opcije ima samo menije iz izabranog restorana
                if (Zahtev.MojMeni != null)
                    MeniId = Zahtev.MojMeni.Id;
                /*MeniOptions = _context.Meniji.Include(x => x.MojProstor).OrderBy(x => x.MojProstor.Id).Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv + ": restoran " + a.MojProstor.Naziv
                                                         }).ToList();*/
                if (Zahtev.MojaDekoracija != null)
                    DekoracijaId = Zahtev.MojaDekoracija.Id;
                DekoracijaOptions = _context.Dekoracije.Select(a =>
                                                         new SelectListItem
                                                         {
                                                             Value = a.Id.ToString(),
                                                             Text = a.Naziv
                                                         }).ToList();
                if (Zahtev.MojaMuzika != null)
                    MuzikaId = Zahtev.MojaMuzika.Id;
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
}