using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WebWedding.Pages
{
    public class OrganizatorAzuriranjeProstoraModel : PageModel
    {

        public WebWeddingContext _db { get; set; }

        [BindProperty]
        public Prostor novProstor { get; set; }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }

        [BindProperty]
        public IFormFile Slikaa { get; set; }

        public OrganizatorAzuriranjeProstoraModel (WebWeddingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public int OrganizatorID { get; set; }
        public async Task<ActionResult> OnGetAsync(int id)
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                ID = id;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
            
        }

        public async Task<ActionResult> OnPostDodajAsync()
        {
            parse = int.TryParse(HttpContext.Session.GetString("idOrganizator"), out int idOrganizator);
            if (parse)
            {
                OrganizatorID = idOrganizator;
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {

                    Console.WriteLine(Slikaa.ContentType);
                    if (Slikaa == null || !Slikaa.ContentType.Contains("image") || Slikaa.Length == 0)
                    {

                        return Page();
                    }
                    else
                    {

                        CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=webwedding;AccountKey=22C3qJb3RstGNtkwfJaFhYHGyrU9Wy45Oojd344RMCUKVxGnjSzIh0PtFuxxoW/Nq7J7GG5s0UPiIUbTPPLYpg==;EndpointSuffix=core.windows.net");

                        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                        CloudBlobContainer container = blobClient.GetContainerReference("123");
                        //Console.WriteLine(noviProizvod.MojProdavac_.ID.ToString());
                        if (await container.CreateIfNotExistsAsync())
                        {
                            await container.SetPermissionsAsync(
                                new BlobContainerPermissions
                                {
                                    PublicAccess = BlobContainerPublicAccessType.Blob
                                });
                        }
                        //ovako treba al kad ubacimo za logovanje na svakoj strani onda ce da ima smisla za sad ime nek bude samo datum
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(/*idProdavac.ToString() +*/ DateTime.Now.ToString().Replace("/", "-") + ".jpg");

                        await blockBlob.UploadFromStreamAsync(Slikaa.OpenReadStream());
                        var uriBuilder = new UriBuilder(blockBlob.Uri);
                        uriBuilder.Scheme = "https";
                        var fullPath = uriBuilder.ToString();
                        novProstor.Slika = fullPath;
                        novProstor.StatusPrikaza = "Prikaz";
                        await _db.Prostori.AddAsync(novProstor);
                        await _db.SaveChangesAsync();
                        return RedirectToPage("../OrganizatorPages/OrganizatorONama");



                    }
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
    }
}
