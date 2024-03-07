﻿
using Platform.Application.Features.Commands.Definitions.Company.Create;
using Platform.Application.Features.Commands.Definitions.Company.Delete;
using Platform.Application.Features.Commands.Definitions.Company.Update;
using Platform.Application.Features.Queries.Definitions.Company.GetAll;
using Platform.Application.Features.Queries.Definitions.Company.GetById;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyController : ControllerBase
    {
        readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompany([FromQuery] RequestGetAllCompany requestGetAllCompany)
        {
            ResponseGetAllCompany response = await _mediator.Send(requestGetAllCompany);

            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdCompany([FromRoute] RequestGetByIdCompany requestGetByIdCompany)
        {
            ResponseGetByIdCompany response = await _mediator.Send(requestGetByIdCompany);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] RequestCreateCompany request)
        {
            ResponseCreateCompany response = await _mediator.Send(request);

            //return Ok(response);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] RequestUpdateCompany request)
        {
            ResponseUpdateCompany response = await _mediator.Send(request);

            return Ok(response);
            //return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] RequestDeleteCompany request)
        {
            ResponseDeleteCompany response = await _mediator.Send(request);
            return Ok(response);
        }
    }

}
