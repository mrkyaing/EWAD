using CloudPOSAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CloudPOSAPI.Services
{
    public class TokenService : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserModel Authenticate(UserModel user)
        {
            var currentUser = GetUsers().FirstOrDefault(x => x.Username.ToLower() ==
                 user.Username.ToLower() && x.Password == user.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        public TokenModel GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);


            return new TokenModel() { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }     
        private List<UserModel> GetUsers()
        {
            List<UserModel> Users = new()
            {
                    new UserModel(){ Username="naeem",Password="naeem_admin",Role="Admin"},
                    new UserModel(){ Username="mk",Password="mk123",Role="Admin"},
                    new UserModel(){ Username="susu",Password="susu123",Role="Staff"}
            };
            return Users;
    }
    }
}
