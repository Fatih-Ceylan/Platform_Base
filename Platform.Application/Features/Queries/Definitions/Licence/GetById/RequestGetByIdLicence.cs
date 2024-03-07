using MediatR;

namespace Platform.Application.Features.Queries.Definitions.Licence.GetById
{
    public class RequestGetByIdLicence : IRequest<ResponseGetByIdLicence>
    {
        public string Id { get; set; }
    }
}
