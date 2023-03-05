using Challenge.ApplicationService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        IImporterApplicationService ImporterService { get; }

        public UploadController(IImporterApplicationService importerApplicationService)
        {
            ImporterService = importerApplicationService; 
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                await ImporterService.ImportAsync(file.OpenReadStream());
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
