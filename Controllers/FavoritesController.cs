using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimePlace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        public IAddToListService AddToListService { get; }

        [Authorize]
        [HttpPost("Character/{id}")]
        public async Task<IActionResult> AddCharacterToFavorites(int id)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId == null)
            {
                return NotFound();
            }
            
            await this.favoritesService.AddCharacterToFavoritesAsync(id, userId);
            return Ok();
            
        }

        [Authorize]
        [HttpPost("Anime/{id}")]
        public async Task<IActionResult> AddAnimeToFavorites(int id)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return base.RedirectToAction();
            }

            await this.favoritesService.AddAnimeToFavoritesAsync(id, userId);
            return Ok();

        }

        
        [HttpGet("Anime/{id}")]
        public async Task<IActionResult> CheckAnimeFavorites(int id)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return base.RedirectToAction();
            }

            var result = this.favoritesService.CheckAnimeFavorite(id, userId);

            return Ok(result);

        }
    }
}
