using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Constants;
using AnimePlace.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimePlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetCountsService getCountsService;

        public HomeController(ILogger<HomeController> logger, IGetCountsService getCountsService)
        {
            this._logger = logger;
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            //ViewData[MessageConstants.ErrorMessage] = "хей, нещо се счупи!";

            var viewModel = this.getCountsService.GetCounts();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}