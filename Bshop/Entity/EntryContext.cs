﻿using Bshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Bshop.Entity
{
    public class EntryContext:DbContext
    {
        private string ConnectionPath =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=turok2008;" +
            "Database = bshop;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<EntryModel> Entrys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntryModel>(s => s.ToTable("entry"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
