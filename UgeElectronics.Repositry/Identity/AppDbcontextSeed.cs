using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Identity;
namespace UgeElectronics.Repositry.Identity
{
    public static class AppDbcontextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "se7a.Mohesen",
                    Email = "se7a@gmail.com",
                    UserName = "se7aMohesen",
                    PhoneNumber = "01285220258"


                };
                await userManager.CreateAsync(User, "P@ssw0rd");
            }
        }

        public static async Task SeedUserAsync(AppIdentityContext dbContext)
        {
            throw new NotImplementedException();
        }
    }

}

