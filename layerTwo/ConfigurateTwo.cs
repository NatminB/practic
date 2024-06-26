using Microsoft.Extensions.DependencyInjection;
using layerOne;
using AutoMapper;
using layerTwo.profiles;
using layerTwo.Interfaces;
using layerTwo.Services;

namespace layerTwo
{
    public static class ConfigurateTwo
    {
        public static void ConfigureBLLServices(this IServiceCollection services)
        {
            services.ConfigureDALServices();
            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new BookProfile());
                mc.AddProfile(new RentProfile());
            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IRentService, RentService>();
        }
    }
}
