using Platform.Application.Absractions.Services;
using Platform.Application.DTOs.Identity.Auth.Login;
using Microsoft.AspNetCore.Identity;
using T = Platform.Domain.Entities.Identity;
using Platform.Application.Absractions.Token;
using Platform.Application.DTOs.Identity;
using Platform.Application.Exceptions;
using Platform.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
namespace Platform.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<T.AppUser> _userManager;
        readonly SignInManager<T.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IAppUserService _appUserService;

        public AuthService(ITokenHandler tokenHandler, SignInManager<T.AppUser> signInManager, UserManager<T.AppUser> userManager, IAppUserService appUserService)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
            _appUserService = appUserService;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            T.AppUser appUser = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (appUser == null)
            {
                await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if (appUser == null)
            {
                throw new NotFoundUserException();
            }
            //TODO: şifre kilitleme canlıya alınırken açılacak

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded) // Authentication başarılı!
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(30);
                await _appUserService.UpdateRefreshTokenAsync(token.RefreshToken, appUser, token.ExpiryDate, 3600);

                return new()
                {
                    Token = token
                };
            }
            else
            {
                throw new AuthenticationErrorException();
            }
        }

        public async Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (appUser != null && appUser?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(3600);
                await _appUserService.UpdateRefreshTokenAsync(refreshToken, appUser, tokenDTO.ExpiryDate, 3600);
                return new()
                {
                    Token = tokenDTO
                };
            }
            else
            {
                throw new NotFoundUserException();
            }
        }
    }
}
