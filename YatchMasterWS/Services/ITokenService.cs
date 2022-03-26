using System.Security.Claims;

namespace YatchMasterWS.Services
{
    public interface ITokenService
    {
        string AccessToken(string SecretKey, IEnumerable<Claim> claims);
                
        ClaimsPrincipal GetPrincipalFromExpiredToken(string SecretKey, string token);
    }
}
