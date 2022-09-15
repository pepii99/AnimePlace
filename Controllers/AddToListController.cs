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

        
        //TODO: Redirect user to log in page if not authorized.

        [HttpPost("Watching/{id}")]
        public async Task<IActionResult> AddToWatchingList(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Ok();
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
                return Ok();
            }

            await this.addToListService.GetAnimeInListStatusAsync(id, userId, "completed");

            return Ok(200);
        }

        [HttpPost("Plan To Watch/{id}")]
        public async Task<IActionResult> AddToPlanToWatch(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Ok();
            }

            await this.addToListService.GetAnimeInListStatusAsync(id, userId, "Plan To Watch");

            return Ok(200);
        }

        [HttpGet("CheckUserList/{id}")]
        public async Task<IActionResult> CheckUserList(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Ok();
            }

            string response = await this.addToListService.CheckUserList(id, userId);

            return Ok(response);
        }
    }
}
