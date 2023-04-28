using Model.Models;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRepository.Interface
{
    public interface IUserBR
    {
        Task<string> AddUser(UserInfo userInfo);
        Task<string> UserLogin(LoginRequest loginRequest);
    }
}
