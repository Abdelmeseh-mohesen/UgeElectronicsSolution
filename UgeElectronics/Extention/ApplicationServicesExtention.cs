
using Sales_System.Api.Helpers;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;
using UgeElectronics.Respository;
using UgeElectronics.Services;

namespace UgeElectronics.Api.Extentions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {

           

            Services.AddSignalR();

           Services.AddScoped(typeof(IProductService), typeof(ProductService));
           Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
           Services.AddScoped(typeof(ISearchService), typeof(SearchService));
           Services.AddScoped(typeof(IFavouriteService), typeof(FavouriteService));
           Services.AddScoped(typeof(IOrderService), typeof(OrderService));
       

            #region Config AutoMapper 
            Services.AddAutoMapper(cfg => cfg.AddProfile(typeof(ProfilesMapping)));
            #endregion

            #region cfg igeneric
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion       

            return Services;

        }
    }



}
