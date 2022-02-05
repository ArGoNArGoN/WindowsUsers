using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsUsers.Controllers
{
    [Route("Users/[controller]")]
    [ApiController]
    public class AccountController
        : ControllerBase
    {
        [HttpGet]
        public IActionResult Account()
        {
            return base.Content("<div>Hello</div>", "text/html");
        }
    }
}
