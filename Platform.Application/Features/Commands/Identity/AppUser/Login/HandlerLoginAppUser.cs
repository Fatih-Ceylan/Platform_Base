using AutoMapper;
using Platform.Application.Absractions.Services;
using Platform.Application.DTOs.Identity.Auth.Login;
using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.Login
{
    public class HandlerLoginAppUser : IRequestHandler<RequestLoginAppUser, ResponseLoginAppUser>
    {
        readonly IAuthService _authService;
        readonly IMapper _mapper;

        public HandlerLoginAppUser(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<ResponseLoginAppUser> Handle(RequestLoginAppUser request, CancellationToken cancellationToken)
        {
            var loginRequestDto = _mapper.Map<LoginRequestDTO>(request);
            var loginResponseDto = await _authService.LoginAsync(loginRequestDto);

            return _mapper.Map<ResponseLoginAppUser>(loginResponseDto);
        }
    }
}
