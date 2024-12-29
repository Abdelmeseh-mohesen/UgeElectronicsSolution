using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Identity;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Services
{
    public class TokenServicecs : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenServicecs(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CraetTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            //Private Clames [User-Defined]
            var authClames = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.UserName),
                  new Claim(ClaimTypes.Email,user.Email),
                 new Claim(ClaimTypes.Role, "Admin") 

            };
            var userRole = await userManager.GetRolesAsync(user);
            foreach (var role in userRole)
                authClames.Add(
                    new Claim(ClaimTypes.Role, role));

            //privet Key 
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));


            //RegisterClames 
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAduienc"],
                expires: DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDay"]!)),
                claims: authClames,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}

