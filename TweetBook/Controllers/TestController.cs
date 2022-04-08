using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TweetBook.Controllers
{

    public class TestController : Controller
    {
        [HttpGet("api/users")]
        public IActionResult Get()
        {
            return Ok(new { Name = "Victor" });
        }
    }
}
