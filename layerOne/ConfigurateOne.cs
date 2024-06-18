using layerOne.interfaces;
using layerOne.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace layerOne
{
    public static class ConfigurateOne
    {
        public static void CofigureDALServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
        }
    }
}
