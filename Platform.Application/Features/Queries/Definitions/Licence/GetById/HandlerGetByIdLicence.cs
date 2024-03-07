using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Queries.Definitions.Licence.GetById
{
    public class HandlerGetByIdLicence : IRequestHandler<RequestGetByIdLicence, ResponseGetByIdLicence>
    {
        readonly IMapper _mapper;
        readonly ILicenceReadRepository _readRepository;

        public HandlerGetByIdLicence(IMapper mapper, ILicenceReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task<ResponseGetByIdLicence> Handle(RequestGetByIdLicence request, CancellationToken cancellationToken)
        {
            T.Licence.Licence licence = await _readRepository.GetByIdAsync(request.Id, false);
            return _mapper.Map<ResponseGetByIdLicence>(licence);
        }
    }
}
