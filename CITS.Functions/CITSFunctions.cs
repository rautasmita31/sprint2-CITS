using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CITS.Entities;
using CITS.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CITS.Functions
{

    public class CITSFunctions
    {
          private readonly CITSDbContext _dal;
        public CITSFunctions(CITSDbContext dal)
        {
            _dal = dal;
            _dal.Database.EnsureCreated();
        }

        [FunctionName("CreateCompanyDetails")]
        public async Task<IActionResult> CreateCompanyDetails(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CompanyDetails companyDetails = JsonConvert.DeserializeObject<CompanyDetails>(requestBody);
            await _dal.CompanyDetails.AddAsync(companyDetails);
            await _dal.SaveChangesAsync();
            return new OkObjectResult(companyDetails);
        }
        [FunctionName("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            EmployeeManagement employeeManagement = JsonConvert.DeserializeObject<EmployeeManagement>(requestBody);
            await _dal.EmployeeManagements.AddAsync(employeeManagement);
            await _dal.SaveChangesAsync();
            return new OkObjectResult(employeeManagement);
        }
        [FunctionName("CreateLeaves")]
        public async Task<IActionResult> CreateLeaves(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LeaveManagement leaveManagement = JsonConvert.DeserializeObject<LeaveManagement>(requestBody);
            await _dal.LeaveManagements.AddAsync(leaveManagement);
            await _dal.SaveChangesAsync();
            return new OkObjectResult(leaveManagement);
        }

        [FunctionName("EmployeeIdExists")]

        public async Task<IActionResult> EmployeeIdExists([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EmployeeIdExists/{employeeid}")] HttpRequest req, int employeeid)
        {

            EmployeeManagement employeemanagement = await _dal.EmployeeManagements.SingleOrDefaultAsync(e => e.EmployeeId == employeeid);

            return new OkObjectResult(employeemanagement != null);
        }

    }

}