using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using CITS.Entities;

namespace CITS.Web.Controllers
{
    public class CompanyDetailsController : Controller
    {
        public IConfiguration Configuration { get; private set; }


        public CompanyDetailsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult CreateCompanyDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompanyDetails(CompanyDetails companyDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string cs = Configuration.GetConnectionString("storageCS");
                    BlobServiceClient client = new BlobServiceClient(cs);
                    string container = "companydetails";
                    BlobContainerClient containerClient = client.GetBlobContainerClient(container);
                    containerClient.CreateIfNotExists();
                    BlobClient blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());
                    blobClient.Upload(new BinaryData(companyDetails));
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(companyDetails);
        }

    }

}


