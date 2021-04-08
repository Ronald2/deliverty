using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/errors/{code}")]
    public class ErrorController : BaseApiController
    {
        public IActionResult GetStatusResponse(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}