using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions.Licence;
using Platform.Persistence.Contexts;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class LicenceReadRepository : ReadRepository<PlatformDbContext, Licence>, ILicenceReadRepository
    {
        public LicenceReadRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
