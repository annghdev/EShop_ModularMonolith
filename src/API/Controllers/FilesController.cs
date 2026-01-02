using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new { message = "ok" });
        }
    }
}
