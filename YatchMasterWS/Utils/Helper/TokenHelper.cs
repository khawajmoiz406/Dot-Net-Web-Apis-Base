using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace YatchMasterWS.Utils.Helper
{
    internal static class TokenHelper
    {
        public static string AccessToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigHelper.GetAppSettings("SecretKey")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.MaxValue,
                signingCredentials: signinCredentials
            );

            var tokenString = tokenHandler.WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
