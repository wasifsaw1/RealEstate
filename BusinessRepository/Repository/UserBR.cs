using BusinessRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Constant;
using Model.DBContext;
using Model.Helper;
using Model.Models;
using Model.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessRepository.Repository
{
    public class UserBR : IUserBR
    {
        private readonly CommonDbContext _dbContext;
        private readonly IConfiguration _iConfiguration;
        public UserBR(CommonDbContext dbContext, IConfiguration iConfiguration)
        {
            _dbContext = dbContext;
            _iConfiguration = iConfiguration;
        }

        public async Task<string> AddUser(UserInfo userInfo)
        {
            if (_dbContext.UserInfo.Any(x=>x.Email.ToUpper() == userInfo.Email.ToUpper()))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, ExceptionConstants.EMAIL_EXIST);
            }
            await _dbContext.UserInfo.AddAsync(userInfo);
            await _dbContext.SaveChangesAsync();
            return $"{userInfo.FirstName +" "+ userInfo.LastName} created successfully";
        }

        public async Task<string> UserLogin(LoginRequest loginRequest)
        {
            UserInfo? userInfo = await _dbContext.UserInfo.Where(x => x.Email == loginRequest.UserName).FirstOrDefaultAsync();
            if(userInfo == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, userInfo.Password))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, ExceptionConstants.INVALID_CREDENTIAL);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iConfiguration["JWT:Key"]);
            var claim = new List<Claim>()
            {
                new Claim("Email", userInfo.Email),
                new Claim("Id", userInfo.Id.ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddMinutes(10),
                Audience = _iConfiguration["JWT:Audience"],
                Issuer = _iConfiguration["JWT:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
