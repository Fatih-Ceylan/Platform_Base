using AutoMapper;
using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Licence.Create
{
    public class HandlerCreateLicence : IRequestHandler<RequestCreateLicence, ResponseCreateLicence>
    {
        readonly ILicenceWriteRepository _licenceWriteRepository;
        readonly IMapper _mapper;

        public HandlerCreateLicence(ILicenceWriteRepository licenceWriteRepository, IMapper mapper)
        {
            _licenceWriteRepository = licenceWriteRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCreateLicence> Handle(RequestCreateLicence request, CancellationToken cancellationToken)
        {
            T.Licence.Licence licence = _mapper.Map<T.Licence.Licence>(request);

            await _licenceWriteRepository.AddAsync(licence);
            await _licenceWriteRepository.SaveAsync();

            return new();
        }
    }
}

