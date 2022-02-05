using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WindowsUsers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var fileContents = System.IO.File.ReadAllText("./Views/Index.html");
            return base.Content(fileContents, "text/html");
        }
    }
}
