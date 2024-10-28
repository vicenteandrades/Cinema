using APIFilmeStudy.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIFilmeStudy.Services;
public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthdayDate.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("958423HSMAC225SecureKey1234567890"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
                expires:DateTime.Now.AddMinutes(20),
                claims : claims,
                signingCredentials : signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

}

