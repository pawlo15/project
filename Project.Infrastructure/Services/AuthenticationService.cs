using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Infrastructure.Data;
using Project.Infrastructure.Models;
using Project.Infrastructure.Models.User;
using Project.Infrastructure.Services.Interfaces.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthenticationService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _dataContext.Users.Include(p => p.UserRoles).ThenInclude(p => p.Role)
                .FirstOrDefaultAsync(u => u.Login.ToLower().Equals(username.ToLower()));

            if (user == default)
                throw new Exception(); // do zrobienia exception handler

            else if (!Veryfication(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(); // do zrobienia exception handler

            else
                response.Data = CreateToken(user);

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();

            if (await UserExists(user.Login))
            {
                response.Message = "Login nie spełnia wymagań";
                return response;
            }

            CreatePassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _dataContext.Users.AnyAsync(u => u.Login.ToLower() == username.ToLower()))
                return true;
            return false;
        }
        private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmacsha512 = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmacsha512.Key;
                passwordHash = hmacsha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool Veryfication(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmacsha512 = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hash = hmacsha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            if (user.UserRoles != default)
            {
                foreach (var item in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Role.Name.ToString()));
                }
            }

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
    }
}
