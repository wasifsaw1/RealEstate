using BusinessLogic.Inteface;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace RealEstate.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _iUserBL;
        public UserController(IUserBL iUserBL)
        {
            _iUserBL = iUserBL;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] UserRequest userRequest)
        {
            try
            {
                return Created("", await _iUserBL.AddUser(userRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginRequest loginRequest)
        {
            try
            {
                return Ok(await _iUserBL.UserLogin(loginRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
