﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Core.Services
{
    public interface ISearchService
    {
        public Task<IReadOnlyCollection<Product>> FiltertionProducts(string productName , string categoryName);
    }
}
