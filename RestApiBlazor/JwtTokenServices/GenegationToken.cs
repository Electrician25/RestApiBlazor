using Microsoft.IdentityModel.Tokens;

namespace RestApiBlazor.JwtTokenServices
{
    public class GenegationToken
    {
        private string CreateToken()
        {
            var key = TokenOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return "";
        }
    }
}