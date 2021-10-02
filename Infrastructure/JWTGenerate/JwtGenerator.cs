using Application.Interface;
using Application.User.CostomizeResponseObject;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.JWTGenerate
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public JwtGenerator(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<Account> CreateToken(string email, string name)
        {
            var Claims = new List<Claim>
            {
                new Claim("email", email),
                new Claim("name", name),
            };

            //generate sign in cridentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:MinuteExpired"])),
                //Expires = DateTime.Now.AddSeconds(10), //add 3 second for test exprise token 
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsUsed = false,
                IsRevorked = false,
                Email = email,
                AddDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(6),
                Token = RandomString(10) + Guid.NewGuid()
            };

            await _context.RefreshToken.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new Account
            {
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token,
                Name = name,
            };
        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(x => x[random.Next(x.Length)]).ToArray());
        }
    }
}
