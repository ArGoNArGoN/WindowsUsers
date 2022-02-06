using Microsoft.AspNetCore.Mvc;

namespace WindowsUsers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController 
        : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content(System.IO.File.ReadAllText("./Views/Index.html"), "text/html");
        }
    }
}
