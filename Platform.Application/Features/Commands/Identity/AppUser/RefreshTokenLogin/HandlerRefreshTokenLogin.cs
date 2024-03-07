using Platform.Application.Absractions.Services;
using Platform.Application.DTOs.Identity;
using Platform.Application.DTOs.Identity.Auth.Login;
using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class HandlerRefreshTokenLogin : IRequestHandler<RequestRefreshTokenLogin, ResponseRefreshTokenLogin>
    {
        readonly IAuthService _authService;

        public HandlerRefreshTokenLogin(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseRefreshTokenLogin> Handle(RequestRefreshTokenLogin request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDto = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new()
            {
                Token = loginResponseDto.Token,
            };
        }
    }
}
