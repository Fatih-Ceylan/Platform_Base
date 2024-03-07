using Platform.Domain.Entities.Common;
using Platform.Domain.Entities.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Platform.Domain.Entities.Identity;
using Platform.Domain.Entities.Definitions.Licence;

namespace Platform.Persistence.Contexts
{
    public class PlatformDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)
        {
        }

        #region Definitions
        public DbSet<Company> Companies { get; set; }
        public DbSet<Licence> Licences { get; set; }
        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region Tüm entitylerde ortak değişiklikler
            //ChangeTracker entitiy üzerinde yapılan değişiklikleri yakalar.

            var datas = ChangeTracker.Entries<BaseEntity>(); //tip base entitiy olarak giren tüm modelleri yakala

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    //TODO: Id added esnasında eklenecek.
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            #endregion

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
