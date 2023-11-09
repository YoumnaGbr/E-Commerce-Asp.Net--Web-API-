using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specfications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : EntityBase
    {
        private readonly StoreContext _dbContext;

        public GenaricRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(Product)) 
            //{
            //    return (IEnumerable<T>)await _dbContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).ToListAsync();
            //}
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        } 

        public async Task<T?> GetByIdAsync(int id)
        {
            //if (typeof(T) == typeof(Product))
            //{
            //    return await _dbContext.Set<Product>().Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;
            //}

            return await _dbContext.Set<T>().FirstAsync();
        }

        public async Task<T?> GetWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpec(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
