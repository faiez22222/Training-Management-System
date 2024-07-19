using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
        public ActionResult<string> Error()
        {
            return "An error occurred";
        }
    }
}
