using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
