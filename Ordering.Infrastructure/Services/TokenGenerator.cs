﻿using Microsoft.IdentityModel.Tokens;
using Ordering.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ordering.Infrastructure.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        //private readonly string _key;
        //private readonly string _issuer;
        //private readonly string _audience;
        //private readonly string _expiryMinutes;
        private readonly JwtSettings _jwtSettings;

        public TokenGenerator(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        //public TokenGenerator(string expiryMinutes, string key, string issuer, string audience)
        //{
        //    _expiryMinutes = expiryMinutes;
        //    _key = key;
        //    _issuer = issuer;
        //    _audience = audience;
        //}

        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var (userId, userName, roles) = userDetails;

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, userId),
                new Claim(ClaimTypes.Name, userName),
                new Claim("UserId", userId)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpiryMinutes)),
                signingCredentials: signingCredentials
            );

            //var token = new JwtSecurityToken(
            //    issuer: _issuer,
            //    audience: _audience,
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_expiryMinutes)),
            //    signingCredentials: signingCredentials
            //);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
