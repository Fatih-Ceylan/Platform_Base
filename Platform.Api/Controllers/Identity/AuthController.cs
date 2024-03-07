using Platform.Application.Features.Commands.Identity.AppUser.Login;
using Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Platform.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(RequestLoginAppUser request)
        {
            ResponseLoginAppUser response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RequestRefreshTokenLogin request)
        {
            ResponseRefreshTokenLogin response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
