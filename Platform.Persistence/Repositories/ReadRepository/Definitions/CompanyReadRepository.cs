using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class CompanyReadRepository : ReadRepository<PlatformDbContext, Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
