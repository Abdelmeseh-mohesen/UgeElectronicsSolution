namespace Sales_System.Api.Configurations.Cors;

public static class CorsExtension
{
    private const string PolicyName = "SalesSystem.Api";

    /// <summary>
    /// Add CORS configurations
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection AddCorsSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var corsConfiguration = new CorsConfigurations();
        configuration.Bind("Cors", corsConfiguration);

        if (corsConfiguration?.Origins == null || !corsConfiguration.Origins.Any())
            throw new Exception("CORS settings configuration could not be loaded or is empty.");

        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, builder =>
            {
                builder.WithOrigins(corsConfiguration.Origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials() // للسماح بمرور الكوكيز والمصادقة
                    .SetIsOriginAllowedToAllowWildcardSubdomains(); // للسماح بالنطاقات الفرعية إذا لزم الأمر
            });
        });

        return services;
    }

    /// <summary>
    /// Setup CORS origins
    /// </summary>
    /// <param name="app"></param>
    public static void UseCorsSetup(this IApplicationBuilder app)
    {
        app.UseCors(PolicyName);
    }
}
