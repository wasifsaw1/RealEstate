using Model.Request;


namespace BusinessLogic.Inteface
{
    public interface IUserBL
    {
        Task<string> AddUser(UserRequest userRequest);
        Task<string> UserLogin(LoginRequest loginRequest);
    }
}
