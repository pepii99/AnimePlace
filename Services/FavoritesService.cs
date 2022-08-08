using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AnimePlace.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly ApplicationDbContext dbContext;

        public FavoritesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public string CheckFavorite(int characterId, string userUserName)
        {
            var user = dbContext.ApplicationUsers.Include("FavoriteCharacters").Where(x => x.UserName == userUserName).FirstOrDefault();
            
            if(user == null || user.FavoriteCharacters.Where(x => x.CharacterId == characterId).FirstOrDefault() == null)
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
