using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Specification;

namespace UgeElectronics.Core.SpecificationHandler
{
    public class CategorySpecification:BaseSpecification<Category>
    {
        public CategorySpecification()
        {
            AddInclude(c => c.Products);
        }
    }
}
