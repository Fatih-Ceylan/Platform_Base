using Platform.Application.Absractions.Services;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Identity;
using Platform.Persistence.Contexts;
using Platform.Persistence.Repositories.ReadRepository.Definitions;
using Platform.Persistence.Repositories.WriteRepository.Definitions;
using Platform.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Platform.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<PlatformDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //TODO: bu alan kurallandırılacak.
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<PlatformDbContext>();



            #region Company
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            #endregion

            #region AppUser
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

            #region Licences
            services.AddScoped<ILicenceReadRepository, LicenceReadRepository>();
            services.AddScoped<ILicenceWriteRepository, LicenceWriteRepository>();
            #endregion

        }
    }
}
