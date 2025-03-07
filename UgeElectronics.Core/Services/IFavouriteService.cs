﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Core.Services
{
    public interface IFavouriteService
    {
        public Task<bool> SwitchIsFavourite(int productId);
        public Task<IReadOnlyCollection<Product>> GetProductIsFavourite();
    }
}
