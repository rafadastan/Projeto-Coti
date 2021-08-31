using Microsoft.IdentityModel.Tokens;
using ProjetoAPI01.CrossCutting.Security.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoApi01.CrossCutting.Security.Services
{
    public class TokenService
    {
        private readonly TokenSettings _settings;

        public TokenService(TokenSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.SecretKey);

            //conteudo do TOKEN
            var tokenDeion = new SecurityTokenDescriptor
            {
                //definições do usuário
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                //tempo de validade do TOKEN
                Expires = DateTime.Now.AddDays(1),

                //criptografia do token
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDeion);
            return tokenHandler.WriteToken(token);
        }
    }
}
