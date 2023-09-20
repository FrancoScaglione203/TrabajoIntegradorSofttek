using Microsoft.IdentityModel.Tokens;
using TrabajoIntegradorSofttek.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TrabajoIntegradorSofttek.Helpers
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration;  //El Iconfiguration trae la clave valor
        public TokenJwtHelper(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]   //La claim manda todo lo que necesita el token que esta en el .jason
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Dni",usuario.Dni.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.RoleId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),  //El tiempo que dura
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}