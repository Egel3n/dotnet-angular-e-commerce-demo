using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Repositories.Customer
{
    public interface ICustomerReadRepository: IReadRepository<ETicaretAPI.Domain.Entities.Customer>
    {
    }
}
