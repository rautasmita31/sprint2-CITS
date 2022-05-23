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
    public class EmployeeManagementController : Controller
    {
        public IConfiguration Configuration { get; private set; }


        public EmployeeManagementController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult CreateEmployeeManagement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployeeManagement(EmployeeManagement employeeManagement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string cs = Configuration.GetConnectionString("storageCS");
                    BlobServiceClient client = new BlobServiceClient(cs);
                    string container = "employeemanagement";
                    BlobContainerClient containerClient = client.GetBlobContainerClient(container);
                    containerClient.CreateIfNotExists();
                    BlobClient blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());
                    blobClient.Upload(new BinaryData(employeeManagement));
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employeeManagement);
        }
    }
}
