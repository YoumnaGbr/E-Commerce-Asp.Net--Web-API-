using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specfications.EmployeeSpec
{
    public class EmployeeWithDeptSpec : BaseSpecifications<Employee>
    {
        public EmployeeWithDeptSpec() : base() 
        {
            Includes.Add(E => E.Department);
        }

        public EmployeeWithDeptSpec(int id) : base(E => E.Id == id)
        {
            Includes.Add(E => E.Department);
        }

    }
}
