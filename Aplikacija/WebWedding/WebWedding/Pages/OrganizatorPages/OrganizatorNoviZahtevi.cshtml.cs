using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebWedding.Pages
{
    public class OrganizatorNoviZahteviModel : PageModel
    {
        public WebWeddingContext _db { get; set; }

        public bool parse { get; set; }

        public OrganizatorNoviZahteviModel(WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IList<Zahtev> Zahtevi { get; set; }

        public bool pom1 { get; set; }
        public bool pom2 { get; set; }
        public bool pom3 { get; set; }
        public bool pom4 { get; set; }
        public bool pom5 { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }


        public async Task<ActionResult> OnGetAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }


        }

      /*  public async Task<ActionResult> OnPostOdobriZahtevAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                Zahtev zahtev = await _db.Zahtevi.FindAsync(id);
                if (zahtev == null)
                    return RedirectToPage("./OrganizatorListaZahteva");

                string pom = "Odobren";
                zahtev.Status = pom;


                //da li je siguran

                await _db.SaveChangesAsync();
                return RedirectToPage("./OrganizatorListaZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostOdbijZahtevAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.Status = "Odbijen";

                //da li je siguran

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }*/
        public async Task<IActionResult> OnPostSacuvajAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                        .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                        .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                if (zahtev.MojProstor!=null)
                {
                    if(zahtev.PotvrdjenoProstor==true)
                    {
                        pom1 = true;
                    }
                    else
                    {
                        pom1 = false;
                    }
                }
                else
                {
                    pom1 = true;
                }

                if (zahtev.MojMeni != null)
                {
                    if (zahtev.PotvrdjenoMeni == true)
                    {
                        pom2 = true;
                    }
                    else
                    {
                        pom2 = false;
                    }
                }
                else
                {
                    pom2 = true;
                }

                if (zahtev.MojaMuzika != null)
                {
                    if (zahtev.PotvrdjenoMuzika == true)
                    {
                        pom3 = true;
                    }
                    else
                    {
                        pom3 = false;
                    }
                }
                else
                {
                    pom3 = true;
                }

                if (zahtev.MojFotograf != null)
                {
                    if (zahtev.PotvrdjenoFotograf == true)
                    {
                        pom4 = true;
                    }
                    else
                    {
                        pom4 = false;
                    }
                }
                else
                {
                    pom4 = true;
                }

                if (zahtev.MojaDekoracija != null)
                {
                    if (zahtev.PotvrdjenoProstor == true)
                    {
                        pom5 = true;
                    }
                    else
                    {
                        pom5 = false;
                    }
                }
                else
                {
                    pom5 = true;
                }

                if (pom1 && pom2 && pom3 && pom4 && pom5)
                {
                    zahtev.Status = "Odobren";
                }
                else
                {
                    zahtev.Status = "Odbijen";
                }
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostOdobriProstorAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoProstor = true;

                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdobriMeniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {

                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoMeni = true;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdobriFotografaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoFotograf = true;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdobriMuzikuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoMuzika = true;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdobriDekoracijuAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoDekoracija = true;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdbijZahtevProstorAsync (int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoProstor = false;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdbijZahtevMeniAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoMeni= false;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdbijZahtevMuzikaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoMuzika = false;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdbijZahtevFotografAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoFotograf = false;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostOdbijZahtevDekoracijaAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                Zahtevi = await _db.Zahtevi.Include(x => x.MojKorisnik).Include(x => x.MojProstor)
                                       .Include(x => x.MojFotograf).Include(x => x.MojMeni)
                                       .Include(x => x.MojaMuzika).Include(x => x.MojaDekoracija).ToListAsync();
                Zahtev zahtev = await _db.Zahtevi.Where(x => x.Id == id).FirstOrDefaultAsync();
                zahtev.PotvrdjenoDekoracija = false;

                await _db.SaveChangesAsync();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostNazadAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                return RedirectToPage("./OrganizatorListaZahteva");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
