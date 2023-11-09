using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specfications;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : EntityBase
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);
            else if (spec.OrderByDesc != null)
                query = query.OrderByDescending(spec.OrderByDesc);
           
            

            query = spec.Includes.Aggregate(query, (currentQuery , includeExpression) => currentQuery.Include(includeExpression));


            return query;
        }

        
    }
}
