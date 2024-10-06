using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace DAL
{
    public static class DalServiceCollectionExtensions
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, string connectionString)
        {
            // Register the DbContext and configure it to use SQL Server
            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddServicesOfAllTypes();
            return services;
        }
    }
}
