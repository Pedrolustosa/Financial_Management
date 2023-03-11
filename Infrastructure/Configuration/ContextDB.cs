using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextDB : IdentityDbContext<ApplicationUser>
    {
        public ContextDB(DbContextOptions options) : base(options) { }



        public DbSet<FinancialSystem> FinancialSystems { get; set; }

        public DbSet<FinancialSystemUser> FinancialSystemUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense> Expenses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);

            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(au => au.Id);

            base.OnModelCreating(builder);
        }

        public static string GetConnectionString()
        {
            return "Data Source=LAPTOP-3D5G6G45;Initial Catalog=FinancialManagementDB;Integrated Security=true;TrustServerCertificate=True";
        }

    }
}
