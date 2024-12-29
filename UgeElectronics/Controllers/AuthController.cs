
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UgeElectronics.Core.Services;
using UgeElectronics.Dtos.AuthDto;

using UgeElectronics.Core.Identity;

namespace UgeElectronics.Controllers
{
    public class AuthController : ApiBaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService tokenService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager ,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto model) // استخدم FromBody بدلاً من FromQuery
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized((401, "Invalid email or password."));

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized((401, "Invalid email or password."));

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await tokenService.CraetTokenAsync(user, userManager) // استخدم tokenService هنا
            });
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromQuery] RegisterDto model)
        {
            var user = new AppUser()
            {
               
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
                UserType = model.UserType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ShopName = model.ShopName, // Seller-specific data
                ShopUrl = model.ShopUrl,
                Street = model.Street,
                Street2 = model.Street2,
                City = model.City,
                PostCode = model.PostCode,
                Country = model.Country,
                State = model.State,
                CompanyName = model.CompanyName,
                CompanyId = model.CompanyId,
                VATNumber = model.VATNumber,
                BankName = model.BankName,
                BankIBAN = model.BankIBAN
            };

            var result = await userManager.CreateAsync(user, model.Password); // Ensure userManager is injected correctly
            if ( !result.Succeeded ) return BadRequest(result.Errors); // Return errors if the creation failed

            return Ok(new UserDto()
            {
                DisplayName=user.DisplayName,
                Email=user.Email,
                Token=await tokenService.CraetTokenAsync(user, userManager) // Ensure tokenService is injected and token generation works
            });
        }




        [HttpGet("allAccounts")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAccounts()
        {
            var users = userManager.Users.ToList();  // Get all users

            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                   Id= user.Id,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await tokenService.CraetTokenAsync(user, userManager)
                };

                usersDto.Add(userDto);
            }

            return Ok(usersDto);
        }



        // Endpoint لإضافة دور لمستخدم
        [HttpPost("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return BadRequest("Role does not exist.");
            }

            var result = await userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok($"Role {roleName} assigned to user {user.UserName} successfully.");
            }

            return BadRequest(result.Errors);
        }

        // Endpoint للحصول على الأدوار الخاصة بمستخدم
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roles = await userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        // Endpoint لإضافة دور جديد للنظام
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                return BadRequest("Role already exists.");
            }

            var result = await roleManager.CreateAsync(new IdentityRole(roleName));

            if (result.Succeeded)
            {
                return Ok($"Role {roleName} created successfully.");
            }

            return BadRequest(result.Errors);
        }
    }
}




