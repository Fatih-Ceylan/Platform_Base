﻿using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class RequestRefreshTokenLogin : IRequest<ResponseRefreshTokenLogin>
    {
        public string RefreshToken { get; set; }
    }
}
