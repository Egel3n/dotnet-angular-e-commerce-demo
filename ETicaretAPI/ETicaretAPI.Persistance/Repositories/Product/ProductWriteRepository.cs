using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories.Product;
using ETicaretAPI.Persistance.Contexts;

namespace ETicaretAPI.Persistance.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<ETicaretAPI.Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
