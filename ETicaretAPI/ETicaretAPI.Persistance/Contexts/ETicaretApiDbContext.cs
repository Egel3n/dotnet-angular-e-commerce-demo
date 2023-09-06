using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using System.Data;
using System.Diagnostics;

namespace ETicaretAPI.Persistance.Contexts
{
    public class ETicaretApiDbContext : DbContext
    {
        public ETicaretApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.Created = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.Updated = DateTime.UtcNow,
                    _ => DateTime.UtcNow,
                    
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }

   

}
