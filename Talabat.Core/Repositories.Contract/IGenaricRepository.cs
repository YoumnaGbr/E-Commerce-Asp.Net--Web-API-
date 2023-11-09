using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specfications;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenaricRepository<T> where T : EntityBase
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<T?> GetWithSpec(ISpecifications<T> spec);
    }
}
