using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimePlace.Controllers
{
    public class CharactersController : Controller
    {

        private readonly ICharactersService charactersService;

        public CharactersController(ICharactersService characterService, UserManager<ApplicationUser> userManager)
        {
            this.charactersService = characterService;
        }

        // Gets character view

        [Route("character/id/")]
        public IActionResult GetById(int id)
        {
            if(id  < 1)
            {
                return NotFound();
            }

            var view = charactersService.GetById(id);

            if(view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        // Adds character to user's favorites (no limits yet)

        [Authorize]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            var currentUser = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (id < 1)
            {
                return NotFound();
            }

            await charactersService.AddToFavorites(id, currentUser);
            return RedirectToAction("/");
        }
    }
}
