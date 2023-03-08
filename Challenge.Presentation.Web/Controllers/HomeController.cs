using Challenge.ApplicationService.Messages.Response;
using Challenge.ClientConnector.Contracts;
using Challenge.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        IChallengeServiceConnector ChallengeServiceConnector { get; }

        //no mundo real isso seria um servico de cache ou servico com a chamada para list individualmente as trasações de cada lojista
        //decidi utilizar essa classe estática para ser mais rapido o desenvolvimento
        static IEnumerable<MerchantResponse> _merchants;

        public HomeController(IChallengeServiceConnector challengeServiceConnector)
        {
            ChallengeServiceConnector = challengeServiceConnector;
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await ChallengeServiceConnector.GetAllMerchants();
            _merchants = merchants;

            return View(merchants);
        }

        public IActionResult Details(long id)
        {
            var merchant = _merchants.FirstOrDefault(m => m.Id == id);

            return View(merchant);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadFileViewModel viewModel)
        {
            await ChallengeServiceConnector.ImportAsync(viewModel.File.OpenReadStream());
            return RedirectToAction("Index");
        }
    }
}