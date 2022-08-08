using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimePlace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddToListController : ControllerBase
    {
        private readonly IAddToListService addToListService;

        public AddToListController(IAddToListService addToListService)
        {
            this.addToListService = addToListService;
        }

        //[HttpPost("{id:int}")]
        [HttpPost("Watching/{id}")]
        public async Task<IActionResult> AddToWatchingList(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return NotFound();
            }

            await this.addToListService.GetAnimeInListStatusAsync(id, userId, "watching");

            return Ok(200);
        }

        [HttpPost("Completed/{id}")]
        public async Task<IActionResult> AddToCompleted(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return NotFound();
            }

            await this.addToListService.GetAnimeInListStatusAsync(id, userId, "completed");

            return Ok(200);
        }

        [HttpPost("PlanToWatch/{id}")]
        public async Task<IActionResult> AddToPlanToWatch(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return NotFound();
            }

            await this.addToListService.GetAnimeInListStatusAsync(id, userId, "planToWatch");

            return Ok(200);
        }
    }
}
