using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entidades;
using API.Interface;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService(IConfiguration config) : ITokenServices
    {
        public string CreateToken(Usuario usuario)
        {
            var tokenkey = config["TokenKey"] ?? throw new Exception("Não foi possivel acessar a chave token pelo appsetings");
            if(tokenkey.Length < 64) throw new Exception("o token deve ser mais longo");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey));

            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}