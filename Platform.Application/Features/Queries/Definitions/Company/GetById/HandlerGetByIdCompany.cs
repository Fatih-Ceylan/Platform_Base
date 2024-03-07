using AutoMapper;
using Platform.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Queries.Definitions.Company.GetById
{
    public class HandlerGetByIdCompany : IRequestHandler<RequestGetByIdCompany, ResponseGetByIdCompany>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;
        public HandlerGetByIdCompany(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseGetByIdCompany> Handle(RequestGetByIdCompany request, CancellationToken cancellationToken)
        {
            T.Company company = await _companyReadRepository.GetByIdAsync(request.Id, false);
            return _mapper.Map<ResponseGetByIdCompany>(company);
        }
    }
}
