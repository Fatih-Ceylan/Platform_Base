using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.Licence.Create;
using Platform.Application.Features.Queries.Definitions.Licence.GetById;
using System.Net;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class LicenceController : ControllerBase
    {
        readonly IMediator _mediator;

        public LicenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdLicence([FromRoute] RequestGetByIdLicence requestGetByIdLicence)
        {
            ResponseGetByIdLicence response = await _mediator.Send(requestGetByIdLicence);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] RequestCreateLicence request)
        {
            ResponseCreateLicence response = await _mediator.Send(request);

            //return Ok(response);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
