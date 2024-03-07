using Platform.Application.DTOs.Identity.AppUser;
using Platform.Domain.Entities.Identity;

namespace Platform.Application.Absractions.Services
{
    public interface IAppUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
