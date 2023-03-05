using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class MerchantsController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAsync()
        {
            return View();
        }
    }
}
