using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TaskService.Helpers;

public static class JwtTokenGenerator
{
    public static string GenerateToken(string username)
    {
        var key =
    new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
            "MyVeryStrongSecretKeyForTaskTracker2026JWT"));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var token =
            new JwtSecurityToken(
                issuer: "TaskTracker",
                audience: "TaskTracker",
                claims: new[]
                {
                    new Claim(
                        ClaimTypes.Name,
                        username)
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
