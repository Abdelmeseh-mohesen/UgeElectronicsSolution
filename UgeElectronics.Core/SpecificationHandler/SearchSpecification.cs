using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq.Expressions;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Specification;

namespace UgeElectronics.Core.SpecificationHandler
{
    public class SearchSpecification : BaseSpecification<Product>
    {
        public SearchSpecification(string? productName, string? categoryName)
            : base(x =>
                (string.IsNullOrEmpty(productName)||x.Name.ToLower().Contains(productName.ToLower()))&&
                (string.IsNullOrEmpty(categoryName)||x.Categorys.Name.ToLower().Contains(categoryName.ToLower()))
            )
        {
            
        }
    }
}
