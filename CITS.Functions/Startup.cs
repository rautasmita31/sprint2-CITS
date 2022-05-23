using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CITS.DAL;

[assembly: FunctionsStartup(typeof(CITS.Functions.Startup))]
namespace CITS.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string sqlCS = Environment.GetEnvironmentVariable("sqlCS");
            builder.Services.AddDbContext<CITSDbContext>((options) => options.UseSqlServer(sqlCS));
        }
    }
}