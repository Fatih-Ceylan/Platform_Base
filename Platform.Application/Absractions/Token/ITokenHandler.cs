using Platform.Application.DTOs.Identity;

namespace Platform.Application.Absractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
