using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace AnimePlace.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly ApplicationDbContext dbContext;

        public FavoritesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAnimeToFavoritesAsync(int animeId, string userId)
        {
            var user = dbContext.ApplicationUsers.Include("FavoriteAnimes").Where(x => x.Id == userId).FirstOrDefault();
            
            var anime = await dbContext.Animes.FindAsync(animeId);



            if (!user.FavoriteAnimes.Contains(anime))
            {
                user.FavoriteAnimes.Add(anime);
                anime.Favorites++;
                
            }
            else
            {
                user.FavoriteAnimes.Remove(anime);
                anime.Favorites--;
                
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task AddCharacterToFavoritesAsync(int characterId, string userId)
        {
            var user = dbContext.ApplicationUsers.Include("FavoriteCharacters").Where(x => x.Id == userId).FirstOrDefault();
            var character = dbContext.Characters.Where(x => x.CharacterId == characterId).FirstOrDefault();

            if (user.FavoriteCharacters.Contains(character))
            {
                user.FavoriteCharacters.Remove(character);
            }
            else
            {
                user.FavoriteCharacters.Add(character);
            }

            await dbContext.SaveChangesAsync();
        }

        public bool CheckAnimeFavorite(int animeId, string userId)
        {
            var user = dbContext.ApplicationUsers.Include("FavoriteAnimes").Where(x => x.Id == userId).FirstOrDefault();

            if (user == null || user.FavoriteAnimes.Where(x => x.AnimeId == animeId).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string CheckCharacterFavorite(int characterId, string userId)
        {
            var user = dbContext.ApplicationUsers.Include("FavoriteCharacters").Where(x => x.UserName == userId).FirstOrDefault();

            if (user == null || user.FavoriteCharacters.Where(x => x.CharacterId == characterId).FirstOrDefault() == null)
            {
                return "Add to favorites";
            }

            else
            {
                return "Remove from favorites";
            }
        }
    }
}
