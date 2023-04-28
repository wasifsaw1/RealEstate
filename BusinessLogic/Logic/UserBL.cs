using BusinessLogic.Inteface;
using BusinessRepository.Interface;
using Model.Constant;
using Model.Helper;
using Model.Models;
using Model.Request;
using System.Text.RegularExpressions;

namespace BusinessLogic.Logic
{
    public class UserBL : IUserBL
    {
        private readonly IUserBR _iUserBR;
        public UserBL(IUserBR iUserBR)
        {
            _iUserBR = iUserBR;
        }

        public async Task<string> AddUser(UserRequest userRequest)
        {
            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$");
            if (!passwordRegex.IsMatch(userRequest.Password))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, ExceptionConstants.INVALID_PASSWORD);
            }
            if(userRequest.Password != userRequest.ConfirmPassword)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, ExceptionConstants.PASSWORD_MISMATCH);
            }
            userRequest.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
            UserInfo userInfo = userRequest.ToUser();
            return await _iUserBR.AddUser(userInfo);
        }

        public async Task<string> UserLogin(LoginRequest loginRequest)
        {
            return await _iUserBR.UserLogin(loginRequest);
        }
    }
}
