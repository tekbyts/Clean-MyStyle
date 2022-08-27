using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Contracts.Persist;

namespace Ordering.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContexts
            var orderContextConnection = configuration.GetConnectionString(nameof(OrderDbContext));
            if (string.IsNullOrEmpty(orderContextConnection))
            {
                throw new ArgumentNullException($"Connection string is not provided while constructing {typeof(OrderDbContext).Name}");
            }

            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(orderContextConnection, options => options.EnableRetryOnFailure(3)));

            // Repositories/Unit of Work
            services.AddScoped<IOrderUow, OrderUow>();



            return services;
        }
    }
}
