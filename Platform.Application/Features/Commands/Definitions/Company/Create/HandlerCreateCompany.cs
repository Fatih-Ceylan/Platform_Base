﻿using AutoMapper;
using Platform.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Company.Create
{
    public class HandlerCreateCompany : IRequestHandler<RequestCreateCompany, ResponseCreateCompany>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly IMapper _mapper;

        public HandlerCreateCompany(ICompanyWriteRepository companyWriteRepository, IMapper mapper)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCreateCompany> Handle(RequestCreateCompany request, CancellationToken cancellationToken)
        {
            T.Company company = _mapper.Map<T.Company>(request);
            //company.Id = Guid.NewGuid();

            await _companyWriteRepository.AddAsync(company);
            await _companyWriteRepository.SaveAsync();

            return new();
        }
    }
}
