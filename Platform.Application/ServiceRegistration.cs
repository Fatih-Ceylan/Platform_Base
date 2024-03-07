using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using Platform.Application.Models;
using System.Reflection;

namespace Platform.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
