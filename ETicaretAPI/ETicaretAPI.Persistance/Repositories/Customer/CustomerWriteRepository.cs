using ETicaretAPI.Application.Repositories.Customer;
using ETicaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<ETicaretAPI.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
