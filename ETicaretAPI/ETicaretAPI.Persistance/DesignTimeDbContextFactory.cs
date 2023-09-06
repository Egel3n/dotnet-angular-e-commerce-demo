using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretApiDbContext>
    {
    
        public ETicaretApiDbContext CreateDbContext(string[] args)
        {
           
            DbContextOptionsBuilder<ETicaretApiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configurations.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
