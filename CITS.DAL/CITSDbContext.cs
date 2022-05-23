using System;
using Microsoft.EntityFrameworkCore;
using CITS.Entities;

namespace CITS.DAL
{
    public class CITSDbContext : DbContext
    {
        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<EmployeeManagement> EmployeeManagements { get; set; }
        public DbSet<LeaveManagement> LeaveManagements { get; set; }

        public CITSDbContext() : base()
        {

        }
        public CITSDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}