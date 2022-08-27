using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            //if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    builder.AddUserSecrets(typeof(OrderDbContextFactory).Assembly);
            //}

            IConfigurationRoot config = builder.Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            var connectionString = config.GetConnectionString(nameof(OrderDbContext));
            dbContextOptionsBuilder
                .UseSqlServer(connectionString);

            return new OrderDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
