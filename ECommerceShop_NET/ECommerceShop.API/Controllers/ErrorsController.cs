using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.API.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error")]
        [HttpGet]
        public ActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}
