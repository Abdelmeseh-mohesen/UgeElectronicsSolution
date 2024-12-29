using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Identity;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Core.Services
{
    public interface ITokenService
    {
        Task<string> CraetTokenAsync(AppUser user, UserManager<AppUser> userManager);

    }
}
