using Model.Models;
using System.ComponentModel.DataAnnotations;


namespace Model.Request
{
    public class UserRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public UserInfo ToUser()
        {
            UserInfo userInfo = new UserInfo()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                MobileNumber = MobileNumber,
                Password = Password,
                CreatedAt = DateTime.UtcNow
            };
            return userInfo;
        }
    }
}
