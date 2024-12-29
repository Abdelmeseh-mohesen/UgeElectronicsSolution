﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Specification
{
    public interface ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Critaria { get; set; } 
        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescening { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginatedEnable { get; set; }


    }
}
