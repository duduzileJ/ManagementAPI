using ManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Data
{
    public class ManagementDb :DbContext
    {
        public ManagementDb(DbContextOptions<ManagementDb>options)
        :base(options)
        {

        }
        public DbSet<EmployeeDetails> EmployeeDetails {get;set;}
        public DbSet<EmployeeDetailsViewModel> EmployeeDetailViewModels {get;set;}
        public DbSet<CandidateDetails> CandidateDetails{get;set;}
    }
}