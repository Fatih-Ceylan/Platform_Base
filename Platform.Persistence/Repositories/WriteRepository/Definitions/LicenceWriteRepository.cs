using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions.Licence;
using Platform.Persistence.Contexts;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class LicenceWriteRepository : WriteRepository<Licence>, ILicenceWriteRepository
    {
        public LicenceWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
