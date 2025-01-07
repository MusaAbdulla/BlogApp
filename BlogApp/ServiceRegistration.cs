using BlogApp.BL.Dtos.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlogApp
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Jwtoptions>
                (configuration.GetSection(Jwtoptions.Jwt));
            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            Jwtoptions jopt= new Jwtoptions();
            jopt.Issuer = configuration.GetSection("JwtOptions")["Issuer"]!;
            jopt.Audience = configuration.GetSection("JwtOptions")["Audience"]!;
            jopt.SecretKey = configuration.GetSection("JwtOptions")["SecretKey"]!;
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jopt.SecretKey))!;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey= signInKey,
                        ValidAudience=jopt.Audience,
                        ValidIssuer=jopt.Issuer,
                        ClockSkew=TimeSpan.Zero
                        
                    };
                });
            return services;
        }
    }
}
