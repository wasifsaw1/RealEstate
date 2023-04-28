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
            Regex emailRegex = new Regex(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+\.)+[a-z]{2,5}$");
            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$");
            if (!emailRegex.IsMatch(userRequest.Email))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, ExceptionConstants.INVALID_EMAIL);
            }
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
