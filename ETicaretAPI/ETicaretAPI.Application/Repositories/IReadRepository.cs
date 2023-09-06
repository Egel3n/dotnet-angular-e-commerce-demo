using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T>  : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> FindWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> FindAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> FindByIdAsync(string id, bool tracking = true);
    }
}
