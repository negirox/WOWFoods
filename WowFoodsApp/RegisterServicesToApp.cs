using WowFoods.Services;
using WowFoodsApp.Repository;

namespace WowFoodsApp
{
    public class RegisterServicesToApp
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterServicesForApp(services);
            RegisterRepositoriesForApp(services);
        }

        private static void RegisterRepositoriesForApp(IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ISalesRepository, SalesRepository>();
        }

        private static void RegisterServicesForApp(IServiceCollection services)
        {
            services.AddTransient<ILoginUserService, LoginUserService>();
            services.AddTransient<ISalesService, SalesService>();
        }
    }
}
