using AnimePlace.Models;
using AnimePlace.Models.ViewModels;

namespace AnimePlace.Services.Contracts
{
    public interface IProfileService
    {
        public ProfileViewModel GetProfile(string user);

    }
}
