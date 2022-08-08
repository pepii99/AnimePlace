using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;

namespace AnimePlace.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext db;

        public ProfileService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ProfileViewModel GetProfile(string userId)
        {
            var View = db.ApplicationUsers.Where(x => x.Id == userId).Select(x => new ProfileViewModel
            {
                Username = x.UserName,
                FavoriteAnimes = x.FavoriteAnimes
                     .Select(x => new FavoriteAnimeViewModel
                     {
                         Id = x.AnimeId,
                         Title = x.Name,
                         ImageUrl = x.ImageUrl,
                     }).ToList(),
                FavoriteCharacters = x.FavoriteCharacters
                     .Select(x => new FavoriteCharacterViewModel
                     {
                         Id = x.CharacterId,
                         Name = x.Name,
                         ImageUrl = x.ImageUrl,
                     }).ToList(),
                CompletedWatchListView = x.CompletedWatchList.CompletedAnimes.Select(x => new CompletedWatchListViewModel
                {
                    AnimeId = x.AnimeId,
                    AnimeImageUrl = x.ImageUrl,
                    AnimeTitle = x.Name
                }).ToList(),
                CurrentlyWatchingListView = x.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Select(x => new CurrentlyWatchingListViewModel
                {
                    AnimeId = x.AnimeId,
                    AnimeImageUrl = x.ImageUrl,
                    AnimeTitle = x.Name
                }).ToList(),
                PlanToWatchListView = x.PlanToWatchList.PlanToWatchAnimeList.Select(x => new PlanToWatchListViewModel
                {
                    AnimeId = x.AnimeId,
                    AnimeImageUrl = x.ImageUrl,
                    AnimeTitle = x.Name
                }).ToList()
            }).First();

            return View;
        }
    }
}
