using AnimePlace.Models;

namespace AnimePlace.Services.Contracts
{
    public interface IFavoritesService
    {
        Task AddCharacterToFavoritesAsync(int characterId, string userName);

        string CheckFavorite(int characterId, string userId);
    }
}
