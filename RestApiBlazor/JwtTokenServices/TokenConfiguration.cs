using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace RestApiBlazor.JwtTokenServices
{
    public static class TokenConfiguration
    {
        public static IServiceCollection AddJwtToken(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = TokenOptions.AUDIENCE,
                    ValidateIssuer = true,
                    ValidIssuer = TokenOptions.ISSUER,
                    ValidateLifetime = true,
                    IssuerSigningKey = TokenOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,

                };
            });
            services.AddAuthorization();

            return services;
        }
    }
}