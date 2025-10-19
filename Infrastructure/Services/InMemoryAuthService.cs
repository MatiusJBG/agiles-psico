using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class InMemoryAuthService : IAuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin", Role = "Admin" },
            new User { Username = "cliente", Password = "cliente", Role = "Client" }
        };

        private readonly IConfiguration _configuration;

        public InMemoryAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var user = _users.SingleOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);

            return new LoginResponse { Token = token, Role = user.Role };
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("role", user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
