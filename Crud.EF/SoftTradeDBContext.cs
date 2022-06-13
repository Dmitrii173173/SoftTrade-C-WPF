using Crud.domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.EF
{
    public class SoftTradeDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public SoftTradeDBContext()
        {

        }
        public SoftTradeDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(e => e.Id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=softtradedb;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
