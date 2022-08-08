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
        [HttpPost("{id}")]
        public async Task<IActionResult> AddToFavorites(int id)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId == null)
            {
                return NotFound();
            }
            
            await this.favoritesService.AddCharacterToFavoritesAsync(id, userId);
            return Ok();
            
        }
    }
}
