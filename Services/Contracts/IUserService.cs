using AnimePlace.Models;

namespace AnimePlace.Services.Contracts
{
    public interface IUserService
    {
        public ApplicationUser GetUser(string userId);
    }
}
