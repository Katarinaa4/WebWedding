using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebWedding.Models;
using Microsoft.AspNetCore.Http;

namespace WebWedding.Pages
{
    public class OrganizatorONamaModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public ICollection<Prostor> mojiProstori { get; set; }

        [BindProperty]
        public ICollection<Muzika> mojaMuzika { get; set; }

        [BindProperty]
        public ICollection<Fotograf> mojiFotografi { get; set; }

        [BindProperty]
        public ICollection<Dekoracija> mojaDekoracija { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public bool parse { get; set; }

        public OrganizatorONamaModel (WebWeddingContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                mojiProstori = await _db.Prostori.Include(x => x.ListaMenija).Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x=>x.StatusPrikaza=="Prikaz").ToListAsync();

                mojaMuzika = await _db.Muzika.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

                mojiFotografi = await _db.Fotografi.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

                mojaDekoracija = await _db.Dekoracije.Include(x => x.Rezervisani).Include(x => x.Zakazani).Where(x => x.StatusPrikaza == "Prikaz").ToListAsync();

                foreach (var prostor in mojiProstori)
                {
                    if (prostor.DatumVazenja == DateTime.Now)
                    {
                        OnPostObrisiProstorAsync(prostor.Id);
                    }
                }

                foreach (var muzika in mojaMuzika)
                {
                    if (muzika.DatumVazenja == DateTime.Now)
                    {
                        OnPostObrisiMuzikuAsync(muzika.Id);
                    }
                }

                foreach (var fotograf in mojiFotografi)
                {
                    if (fotograf.DatumVazenja == DateTime.Now)
                    {
                        OnPostObrisiFotografaAsync(fotograf.Id);
                    }
                }

                foreach (var dekoracija in mojaDekoracija)
                {
                    if (dekoracija.DatumVazenja == DateTime.Now)
                    {
                        OnPostObrisiDekoracijuAsync(dekoracija.Id);
                    }
                }

                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostPromeniStatusAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Prostor zaBrisanje = await _db.Prostori.Include(x => x.ListaMenija).Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();
                zaBrisanje.StatusPrikaza = "NePrikazuj";
                List<Zahtev> listaZahteva = await _db.Zahtevi.Include(x => x.MojProstor).Where(x => x.MojProstor == zaBrisanje).ToListAsync();
                DateTime datum = zaBrisanje.DatumVazenja;
                foreach (var zahtev in listaZahteva)
                {
                    if (zahtev.IzabraniDatum > datum)
                    {
                        datum = zahtev.IzabraniDatum;
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostObrisiProstorAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Prostor zaBrisanje = await _db.Prostori.Include(x => x.ListaMenija).Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

                _db.Prostori.Remove(zaBrisanje);

                List<Meni> meniji = await _db.Meniji.Include(x => x.MojProstor).ToListAsync();
                foreach (var meni in meniji)
                {
                    if (meni.MojProstor == null)
                    {
                        _db.Meniji.Remove(meni);
                    }
                }

                List<ProstorRezervisani> rezervisani = await _db.RezervisaniDatumi.Include(x => x.MojProstor).ToListAsync();
                foreach (var rez in rezervisani)
                {
                    if (rez.MojProstor == null)
                    {
                        _db.RezervisaniDatumi.Remove(rez);
                    }
                }

                List<ProstorZakazani> zakazani = await _db.ZakazaniDatumi.Include(x => x.MojProstor).ToListAsync();
                foreach (var zak in zakazani)
                {
                    if (zak.MojProstor == null)
                    {
                        _db.ZakazaniDatumi.Remove(zak);
                    }
                }

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiMeniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.Meniji.FindAsync(id);
                _db.Meniji.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiZakazaneAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.ZakazaniDatumi.FindAsync(id);
                _db.ZakazaniDatumi.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiRezervisaneAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.RezervisaniDatumi.FindAsync(id);
                _db.RezervisaniDatumi.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");

            }

        }

        public async Task<ActionResult> OnPostObrisiRezervisaneMuzikaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.MuzikaRezervisaniD.FindAsync(id);
                _db.MuzikaRezervisaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiZakazaneMuzikaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.MuzikaZakazaniD.FindAsync(id);
                _db.MuzikaZakazaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostUkloniMuzikuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Muzika zaBrisanje = await _db.Muzika.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();
                zaBrisanje.StatusPrikaza = "NePrikazuj";
                List<Zahtev> listaZahteva = await _db.Zahtevi.Include(x => x.MojaMuzika).Where(x => x.MojaMuzika == zaBrisanje).ToListAsync();
                DateTime datum = zaBrisanje.DatumVazenja;
                foreach (var zahtev in listaZahteva)
                {
                    if (zahtev.IzabraniDatum > datum)
                    {
                        datum = zahtev.IzabraniDatum;
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostObrisiMuzikuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Muzika zaBrisanje = await _db.Muzika.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

                _db.Muzika.Remove(zaBrisanje);

                List<MuzikaRezervisani> rezervisani = await _db.MuzikaRezervisaniD.Include(x => x.MojaMuzika).ToListAsync();
                foreach (var rez in rezervisani)
                {
                    if (rez.MojaMuzika == null)
                        _db.MuzikaRezervisaniD.Remove(rez);
                }

                List<MuzikaZakazani> zakazani = await _db.MuzikaZakazaniD.Include(x => x.MojaMuzika).ToListAsync();
                foreach (var zak in zakazani)
                {
                    if (zak.MojaMuzika == null)
                        _db.MuzikaZakazaniD.Remove(zak);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiZakazaniFotografAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.FotografiZakazaniD.FindAsync(id);
                _db.FotografiZakazaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiRezervisaniFotografAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.FotografiRezervisaniD.FindAsync(id);
                _db.FotografiRezervisaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostUkloniFotografaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Fotograf zaBrisanje = await _db.Fotografi.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();
                zaBrisanje.StatusPrikaza = "NePrikazuj";
                List<Zahtev> listaZahteva = await _db.Zahtevi.Include(x => x.MojFotograf).Where(x => x.MojFotograf == zaBrisanje).ToListAsync();
                DateTime datum = zaBrisanje.DatumVazenja;
                foreach (var zahtev in listaZahteva)
                {
                    if (zahtev.IzabraniDatum > datum)
                    {
                        datum = zahtev.IzabraniDatum;
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostObrisiFotografaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Fotograf zaBrisanje = await _db.Fotografi.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

                _db.Fotografi.Remove(zaBrisanje);

                List<FotografRezervisani> rezervisani = await _db.FotografiRezervisaniD.Include(x => x.MojFotograf).ToListAsync();
                foreach (var rez in rezervisani)
                {
                    if (rez.MojFotograf == null)
                        _db.FotografiRezervisaniD.Remove(rez);
                }

                List<FotografZakazani> zakazani = await _db.FotografiZakazaniD.Include(x => x.MojFotograf).ToListAsync();
                foreach (var zak in zakazani)
                {
                    if (zak.MojFotograf == null)
                        _db.FotografiZakazaniD.Remove(zak);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiRezervisaniDekoracijaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.DekoracijaRezervisaniD.FindAsync(id);
                _db.DekoracijaRezervisaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }

        public async Task<ActionResult> OnPostObrisiZakazaniDekoracijaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                var zaBrisanje = await _db.DekoracijaZakazaniD.FindAsync(id);
                _db.DekoracijaZakazaniD.Remove(zaBrisanje);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage();
            }

        }

        public async Task<ActionResult> OnPostUkloniDekoracijuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Dekoracija zaBrisanje = await _db.Dekoracije.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();
                zaBrisanje.StatusPrikaza = "NePrikazuj";
                List<Zahtev> listaZahteva = await _db.Zahtevi.Include(x => x.MojaDekoracija).Where(x => x.MojaDekoracija == zaBrisanje).ToListAsync();
                DateTime datum = zaBrisanje.DatumVazenja;
                foreach (var zahtev in listaZahteva)
                {
                    if (zahtev.IzabraniDatum > datum)
                    {
                        datum = zahtev.IzabraniDatum;
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostObrisiDekoracijuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Dekoracija zaBrisanje = await _db.Dekoracije.Include(x => x.Zakazani).Include(x => x.Rezervisani).Where(x => x.Id == id).FirstOrDefaultAsync();

                _db.Dekoracije.Remove(zaBrisanje);

                List<DekoracijaRezervisani> rezervisani = await _db.DekoracijaRezervisaniD.Include(x => x.MojaDekoracija).ToListAsync();
                foreach (var rez in rezervisani)
                {
                    if (rez.MojaDekoracija == null)
                        _db.DekoracijaRezervisaniD.Remove(rez);
                }

                List<DekoracijaZakazani> zakazani = await _db.DekoracijaZakazaniD.Include(x => x.MojaDekoracija).ToListAsync();
                foreach (var zak in zakazani)
                {
                    if (zak.MojaDekoracija == null)
                        _db.DekoracijaZakazaniD.Remove(zak);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
    }
}
