using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimePlace.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(UserManager<ApplicationUser> userManager, IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var view = profileService.GetProfile(currentUser);
            if(view == null)
            {
                return NotFound();
            }

            return View(view);
        }
    }
}
