    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
using Sales_System.Api.Configurations.Cors;
using Sales_System.Configurations.Swagger;
using Sales_System.Repository.AppDbContext;
using StackExchange.Redis;
using UgeElectronics.Api.Extentions;
using UgeElectronics.Core.Abstarct;
using UgeElectronics.Core.Identity;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;
using UgeElectronics.Repositry;
using UgeElectronics.Repositry.Identity;
    using UgeElectronics.Services;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
   
//----------------------AppIdentityConnection---------------------
builder.Services.AddDbContext<AppIdentityContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
    });


    builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
    });
// Basket
 //builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
 // {
 //   var connection = builder.Configuration.GetConnectionString("Redis");
 //   return ConnectionMultiplexer.Connect(connection);
 // });
   builder.Services.AddScoped<IBasketServies,BasketServies>();
builder.Services.AddCorsSetup(builder.Configuration);


// إضافة خدمة TokenService
builder.Services.AddScoped<ITokenService, TokenServicecs>();

    // إضافة خدمات الهوية والمصادقة
    builder.Services.AddIdentityServices(builder.Configuration);
    builder.Services.AddApplicationServices();

    var app = builder.Build();

//update database
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();//catch
try
{
    var DbContext = services.GetRequiredService<ApplicationDbContext>();
    await DbContext.Database.MigrateAsync();
    //*DataSeed*
   // await StoreContextSeed.SeedAsync(DbContext);
    //
    var IdentityDbContext = services.GetRequiredService<AppIdentityContext>();
    await IdentityDbContext.Database.MigrateAsync();
    //Identity seed 
    var userManger = services.GetRequiredService<UserManager<AppUser>>();
    await AppDbcontextSeed.SeedUserAsync(userManger);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error during Apply migration");

}
// Configure the HTTP request pipeline.
//if ( app.Environment.IsDevelopment() )
   // {
        app.UseSwagger();
        app.UseSwaggerUI();
  //  }



    app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication(); // هذا يجب أن يكون قبل التفويض
app.UseAuthorization();
app.MapControllers();


app.Run();
