using Bshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Bshop.Entity
{
    public class ClientContext:DbContext
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

        public DbSet<ClientModel> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>(s => s.ToTable("client"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
