using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimePlace.Controllers
{
    public class AnimesController : Controller
    {
        private readonly IAnimesService animesService;

        public AnimesController(IAnimesService animesService)
        {
            this.animesService = animesService;
        }

        // GET: AnimesController
        //public IActionResult Index(int id)
        //{
        //    var viewModel = new AnimesListViewModel
        //    {
        //        PageNumber = id,
        //        Animes = animesService.GetAll(id, 20),
        //    };
        //    return View(viewModel);
        //}

        [Route("animes")]
        public IActionResult AllAnimes(int id = 1)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            const int AnimesPerPage = 30;

            var viewModel = new AnimesListViewModel
            {
                AnimesPerPage = AnimesPerPage,
                PageNumber = id,
                AnimesCount = animesService.GetCount(),
                Animes = animesService.GetAll(id, AnimesPerPage),
            };
            return View(viewModel);

        }

        public IActionResult Create()
        {
            var viewModel = new CreateAnimeInputModel();
            //viewModel.TypeItems

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAnimeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            await this.animesService.CreateAsync(input);
            //return this.Json(input);
            return this.RedirectToAction("AllAnimes", "Animes");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var viewModel = animesService.GetEdit(id);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditAnimeInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }

            await this.animesService.EditAsync(input, id);

            //return this.Json(input);

            return this.RedirectToAction("AllAnimes", "Animes");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var viewModel = animesService.GetEdit(id);


            if (viewModel == null)
            {
                return NotFound();
            }


            return View(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> DeletePOST(int id)
        {
            await animesService.Delete(id);

            return this.RedirectToAction("AllAnimes", "Animes");

        }

        [Route("animes/id")]
        public IActionResult GetById(int id)
        {
            SingleAnimeViewModel anime = animesService.GetById(id);

            if (anime == null)
            {
                return this.NotFound();
            }

            anime.Characters = animesService.GetAllForAnime(id);



            return View(anime);
        }

        [Authorize]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await animesService.AddToFavorites(id, currentUserId);
            return RedirectToAction("GetById");
        }

        //[Authorize]
        //public async Task<IActionResult> AddToCompletedWatchList(int id)
        //{
        //    if (id < 1)
        //    {
        //        return NotFound();
        //    }

        //    var currentUser = userManager.GetUserAsync(this.User);
        //    await animesService.AddToCompletedWatchList(id, currentUser);
        //    return RedirectToAction("Profle/GetProfile");
        //}

        //[Authorize]
        //public async Task<IActionResult> AddToWatchingList(int id)
        //{
        //    if (id < 1)
        //    {
        //        return NotFound();
        //    }

        //    var currentUser = userManager.GetUserAsync(this.User);
        //    await animesService.AddToWatchingList(id, await currentUser);
        //    return RedirectToAction("AllAnimes");
        //}
    }
}
