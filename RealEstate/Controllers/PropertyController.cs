using BusinessLogic.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace RealEstate.Controllers
{
    [Authorize]
    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyBL _iPropertyBL;
        public PropertyController(IPropertyBL iPropertyBL)
        {
            _iPropertyBL = iPropertyBL;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllEstateNames()
        {
            try
            {
                return Ok(await _iPropertyBL.GetAllEstateNames());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstateDetailsByid(int id)
        {
            try
            {
                return Ok(await _iPropertyBL.GetEstateDetailsByid(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddEstate([FromBody] PropertyRequest propertyRequest)
        {
            try
            {
                return Created("", await _iPropertyBL.AddEstate(propertyRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstate(int id, [FromBody] PropertyRequest propertyRequest)
        {
            try
            {
                return Ok(await _iPropertyBL.UpdateEstate(id, propertyRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstate([FromQuery] int id)
        {
            try
            {
                return Ok(await _iPropertyBL.DeleteEstate(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
