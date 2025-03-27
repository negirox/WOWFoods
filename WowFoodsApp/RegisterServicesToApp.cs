using WowFoodsApp.Repository;

namespace WowFoodsApp
{
    public class RegisterServicesToApp
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ISalesRepository, SalesRepository>();
        }
    }
}
