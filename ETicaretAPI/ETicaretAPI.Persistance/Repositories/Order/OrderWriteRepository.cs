using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<ETicaretAPI.Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
