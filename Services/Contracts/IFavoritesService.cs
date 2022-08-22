using AnimePlace.Models;

namespace AnimePlace.Services.Contracts
{
    public interface IFavoritesService
    {
        Task AddCharacterToFavoritesAsync(int characterId, string userId);

        string CheckCharacterFavorite(int characterId, string userId);

        Task AddAnimeToFavoritesAsync(int animeId, string userId);

        bool CheckAnimeFavorite(int characterId, string userId);
    }
}
