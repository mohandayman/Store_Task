using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace BL
{
    public static class BLServiceCollectionExtensions
    {
        public static IServiceCollection AddBLServices(this IServiceCollection services, string connectionString)
        {
            // Register the DbContext and configure it to use SQL Server
            services.AddDalServices(connectionString);
            services.AddServicesOfAllTypes();

            return services;
        }
    }
}
