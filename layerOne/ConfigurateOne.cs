using layerOne.interfaces;
using layerOne.models;
using layerOne.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace layerOne
{
    public static class ConfigurateOne
    {
        public static void ConfigureDALServices(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseInMemoryDatabase("Library"));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
