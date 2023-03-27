using BusinessLogicLayer.Repository;
using BusinessLogicLayer.Services;
using DataAcessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebAPI.Extensions
{
    public static class DiExtensions
    {
        public static IServiceCollection AddSQL(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(
                        configuration.GetConnectionString("SqlDatabase"),
                        b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName))
                    .UseLazyLoadingProxies();
            }   
            );
            return services;
        }

        public static IServiceCollection AddService(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddScoped<IGenericRepository,GenericRepository>();
            services.AddScoped<IUserService,UserService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
