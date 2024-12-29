using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UgeElectronics.Core.Identity;
using UgeElectronics.Core.Services;
using UgeElectronics.Repositry.Identity;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit=true;
            options.Password.RequireLowercase=true;
            options.Password.RequireUppercase=true;
            options.Password.RequireNonAlphanumeric=true;
        })
        .AddEntityFrameworkStores<AppIdentityContext>()
        .AddDefaultTokenProviders();

        // إعداد المصادقة باستخدام JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Events=new JwtBearerEvents
                {
                    OnMessageReceived=context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        if ( !string.IsNullOrEmpty(accessToken) )
                        {
                            context.Token=accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidIssuer=configuration["JWT:ValidIssuer"],
                    ValidateAudience=true,
                    ValidAudience=configuration["JWT:ValidAudience"],
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

        // إعداد سياسات الأدوار
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });

        return services;
    }

    // تهيئة الأدوار عند بدء التشغيل
    public static async Task CreateRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roleNames = { "Admin", "User" };

        foreach ( var roleName in roleNames )
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if ( !roleExist )
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
