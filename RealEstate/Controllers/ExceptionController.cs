using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Helper;
using Model.Response;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        public ExceptionResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = 500; 

            if (exception is HttpException httpException)
            {
                code = (int)httpException.Status;
            }

            Response.StatusCode = code;

            return new ExceptionResponse(exception);
        }
    }
}
