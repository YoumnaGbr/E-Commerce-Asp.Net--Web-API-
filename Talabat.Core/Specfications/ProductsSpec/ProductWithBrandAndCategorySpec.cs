using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specfications.ProductsSpec
{
    public class ProductWithBrandAndCategorySpec : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpec(string sort) :base()
        {
            AddIncludes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                         AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default: AddOrderBy(P => P.Name); 
                        break;
                }
            }
            else
                AddOrderBy(P => P.Name);
        }


        public ProductWithBrandAndCategorySpec(int id)
            :base(P => P.Id == id) 
        {
            AddIncludes();
        }
       
        private void AddIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }


    }
}
