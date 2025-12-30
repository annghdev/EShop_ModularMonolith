using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Catalogs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new { message = "ok" });
        }
    }
}
