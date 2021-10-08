using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using WebWedding.Models;

namespace WebWedding.Pages.OrganizatorPages
{
    public class OrganizatorDodajSlikuModel : PageModel
    {
        [BindProperty]
        public IFormFile Slika { get; set; }

        [BindProperty]
        public Slika novaSlika { get; set; }

        public WebWeddingContext _db { get; set; }
        [BindProperty]
        public int OrganizatorID { get; set; }

        public OrganizatorDodajSlikuModel(WebWeddingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int ID { get; set; }

        public bool parse { get; set; }


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

                    Console.WriteLine(Slika.ContentType);
                    if (Slika == null || !Slika.ContentType.Contains("image") || Slika.Length == 0)
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

                        await blockBlob.UploadFromStreamAsync(Slika.OpenReadStream());
                        var uriBuilder = new UriBuilder(blockBlob.Uri);
                        uriBuilder.Scheme = "https";
                        var fullPath = uriBuilder.ToString();
                        novaSlika.slika = fullPath;
                        await _db.Slike.AddAsync(novaSlika);
                        await _db.SaveChangesAsync();
                        return RedirectToPage("./OrganizatorGalerija");



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
