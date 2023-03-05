using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class MerchantsController : ControllerBase
    {
        IMerchantApplicationService MerchantApplicationService { get; }

        public MerchantsController(IMerchantApplicationService merchantApplicationService)
        {
            MerchantApplicationService = merchantApplicationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MerchantResponse>> GetAllAsync() => await MerchantApplicationService.GetAll();

    }
}
