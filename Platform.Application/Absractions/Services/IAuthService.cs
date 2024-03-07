using Platform.Application.DTOs.Identity.Auth.Login;

namespace Platform.Application.Absractions.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);
        Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken);
    }
}
