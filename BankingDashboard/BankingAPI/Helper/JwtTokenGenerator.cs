using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BankingAPI.Helper
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username, string role)
        {
            var secretKey = _configuration["JwtSettings:Key"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT secret key is missing in configuration.");
            }

            byte[] keyBytes;
            try
            {
                keyBytes = Convert.FromBase64String(secretKey);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("JWT secret key is not a valid Base64 string.");
            }

            if (keyBytes.Length < 32)
            {
                throw new InvalidOperationException("JWT secret key must be at least 256 bits (32 bytes).");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signingCredentials)
            {
                { "kid", "your-key-id" } // Add the key ID
            };

            var payload = new JwtPayload
            {
                { "sub", username },
                { "iss", _configuration["JwtSettings:Issuer"] },
                { "aud", _configuration["JwtSettings:Audience"] },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpireMinutes"])).ToUnixTimeSeconds() }
            };

            var token = new JwtSecurityToken(header, payload);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }

    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, string role);
    }
}

