using Microsoft.IdentityModel.Tokens;
using RESTapi.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestApiBlazor.JwtTokenServices
{
    public class GenegationToken
    {
        private string CreateToken(User user)
        {
            var key = TokenOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: TokenOptions.ISSUER,
                audience: TokenOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials
            );

            var jwtSecurityHandler = new JwtSecurityTokenHandler();

            return jwtSecurityHandler.WriteToken(token);
        }
    }
}