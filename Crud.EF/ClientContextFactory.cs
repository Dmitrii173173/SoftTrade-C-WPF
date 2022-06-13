using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.EF
{
    public class ClientContextFactory : IDesignTimeDbContextFactory<SoftTradeDBContext>
    {
        public SoftTradeDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SoftTradeDBContext>();
            options.UseSqlServer("Server=.; Database=softtradedb;Trusted_Connection=True");
            return new SoftTradeDBContext(options.Options);
        }
    }
}
