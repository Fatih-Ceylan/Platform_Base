using Platform.Application.Absractions.Token;
using Platform.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Platform.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
       }
    }
}
