using Bshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Bshop.Entity
{
    public class MasterContext:DbContext
    {
        private string ConnectionPath =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=turok2008;" +
            "Database=barbershopDB;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<MasterModel> Master { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterModel>(s => s.ToTable("master"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
