using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Services
{
    public class TokenService
    {
        public static string GenerateToken (UserModels user)
        {
            var key = Encoding.ASCII.GetBytes(Key.SecretKey); //chamando minha chave privada
            var tokenConfig = new SecurityTokenDescriptor //configura da maneira com que deseja
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("NomeUsuario", user.NomeUsuario.ToString()),
                    new Claim("SenhaUsuario", user.SenhaUsuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);

            return tokenHandler.WriteToken(token);
        }
    }
}
