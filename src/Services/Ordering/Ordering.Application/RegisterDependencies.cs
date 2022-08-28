using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // Require AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Require MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Application Services/Dependencies

            return services;
        }
    }
}
