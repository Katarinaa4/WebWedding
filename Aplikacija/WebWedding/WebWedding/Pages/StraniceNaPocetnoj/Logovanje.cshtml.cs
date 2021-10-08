using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebWedding.Pages
{
    public class LogovanjeModel : PageModel
    {
        public string Message { get; set; }

        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public Korisnik primer { get; set; }
        public LogovanjeModel(WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int Type { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostLogin()
        {


            Administrator admin = _db.Administrator.Where(x => x.Email == primer.Email).SingleOrDefault();

            if (admin != null)
            {
                if (primer.Sifra == admin.Sifra)
                {
                    HttpContext.Session.SetString("idAdmin", admin.Id.ToString());
                    return RedirectToPage("../AdminPages/AdminPocetna");
                }
                else
                {
                    Type = 1;
                    Message = "Email i sifra se ne poklapaju!";
                    return Page();
                }
            }
            else
            {
                Organizator organizator = _db.Organizatori.Where(x => x.Email == primer.Email).SingleOrDefault();
                if (organizator != null)
                {
                    //if (!organizator.Verifikovan)
                    // {
                    // Message = "Nalog vam jos nije verifikovan!";
                    // return Page();
                    //}
                    // else
                    // {
                    if (primer.Sifra == organizator.Sifra)
                    {
                        if(organizator.Arhivirano==false)
                        { 
                        HttpContext.Session.SetString("idOrganizator", organizator.Id.ToString());
                        return RedirectToPage("../OrganizatorPages/OrganizatorPocetna");
                        }
                        else
                        {
                            Type = 1;
                            Message = "Vas nalog vise nije aktivan!";
                            return Page();
                        }
                    }
                    else
                    {
                        Type = 1;
                        Message = "Email i sifra se ne poklapaju!";
                        return Page();
                    }
                }
                else
                {
                    Korisnik korisnik = _db.Korisnici.Where(x => x.Email == primer.Email).SingleOrDefault();
                    if (korisnik != null)
                    {
                        if (primer.Sifra == korisnik.Sifra)
                        {
                            if (korisnik.Arhivirano == false)
                            {
                                HttpContext.Session.SetString("idKorisnik", korisnik.Id.ToString());
                                return RedirectToPage("../KorisnikPages/KorisnikPocetna");
                            }
                            else
                            {
                                Type = 1;
                                Message = "Vas nalog vise nije aktivan!";
                                return Page();
                            }
                        }
                        else
                        {
                                Type = 1;
                                Message = "Email i sifra se ne poklapaju!";
                                return Page();
                        }
                    }
                    else
                    {
                        Type = 2;
                        Message = "Niste se registrovali! Molimo Vas regustrujte se za nastavak.";
                        return Page();
                    }
                }
            }
        }
    }
}

           
    //        else if (Type == 0)
    //        {
    //           Korisnik korisnik = _db.Korisnici.Where(x => x.Email == primer.Email).SingleOrDefault();
    //           if (korisnik != null && primer.Sifra == korisnik.Sifra)
    //            {
    //                HttpContext.Session.SetString("idKorisnik", korisnik.Id.ToString());
    //                return RedirectToPage("../KorisnikPages/KorisnikPocetna");
    //            }
    //            else
    //            {
    //                Message = "Email i sifra se ne poklapaju!";
    //                return Page();
    //            }
    //        }
    //        else
    //        {
    //            Organizator organizator = _db.Organizatori.Where(x => x.Email == primer.Email).SingleOrDefault();
    //           if (organizator != null && primer.Sifra == organizator.Sifra)
    //            {
    //                //if (!organizator.Verifikovan)
    //               // {
    //                   // Message = "Nalog vam jos nije verifikovan!";
    //                   // return Page();
    //                //}
    //               // else
    //               // {
    //                    HttpContext.Session.SetString("idOrganizator", organizator.Id.ToString());
    //                    return RedirectToPage("../OrganizatorPages/OrganizatorPocetna");
    //               // }
    //            }
    //            else
    //            {
    //               Message = "Email i sifra se ne poklapaju!";
    //                return Page();
    //            }
    //        }
    //    }
    //}

