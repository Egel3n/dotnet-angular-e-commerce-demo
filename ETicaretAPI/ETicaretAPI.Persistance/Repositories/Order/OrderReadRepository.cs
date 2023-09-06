using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<ETicaretAPI.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
