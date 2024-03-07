using Platform.Application.Absractions.Services;
using Platform.Application.DTOs.Identity.AppUser;
using Platform.Application.Exceptions;
using Platform.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using T = Platform.Domain.Entities.Identity;

namespace Platform.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<T.AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
            }, model.Password);

            CreateUserResponseDTO response = new() { Succeed = result.Succeeded };
            if (!result.Succeeded)
            {
                response.Message = "";
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} \n ";
                }
            }

            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }
    }
}
