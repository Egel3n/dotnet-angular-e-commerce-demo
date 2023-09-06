using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories.Product;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<ETicaretAPI.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
