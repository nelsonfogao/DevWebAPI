using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class AuthenticateService
    {
        private AmigoRepository Repository { get; set; }

        private IConfiguration Configuration { get; set; }

        public AuthenticateService(AmigoRepository repository, IConfiguration configuration)
        {
            this.Repository = repository;
            this.Configuration = configuration;
        }

        public string AuthenticateUser(string email, string senha)
        {
            var amigo = this.Repository.GetAmigoByEmail(email);

            if (amigo == null)
                return null;

            if (amigo.Senha != senha)
                return null;

            return CreateToken(amigo);
        }

        private string CreateToken(Amigo amigo)
        {
            var key = Encoding.UTF8.GetBytes(this.Configuration["Token:Secret"]);

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, amigo.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, amigo.Nome));
            claims.Add(new Claim(ClaimTypes.Email, amigo.Email));
            claims.Add(new Claim("senha", amigo.Senha));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = "AMIGO-API",
                Issuer = "AMIGO-API"
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
