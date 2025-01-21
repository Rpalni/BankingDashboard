using BankingAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Database
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FundTransfer> FundTransfer { get; set; }
        public DbSet<Login> Login { get; set; }
    }

}
