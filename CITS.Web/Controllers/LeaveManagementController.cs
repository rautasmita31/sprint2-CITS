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
    public class LeaveManagementController : Controller
    {
        public IConfiguration Configuration { get; private set; }


        public LeaveManagementController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult CreateLeaves()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLeaves(LeaveManagement leaveManagement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string cs = Configuration.GetConnectionString("storageCS");
                    BlobServiceClient client = new BlobServiceClient(cs);
                    string container = "leavemanagement";
                    BlobContainerClient containerClient = client.GetBlobContainerClient(container);
                    containerClient.CreateIfNotExists();
                    BlobClient blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());
                    blobClient.Upload(new BinaryData(leaveManagement));
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(leaveManagement);
        }

    }
}