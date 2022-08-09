using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnimePlace.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly ApplicationDbContext dbContext;
        
        public CharactersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        

        public async Task AddToFavorites(int id, string userId)
        {
            var character = dbContext.Characters.Where(x => x.CharacterId == id).First();
            var userdb = dbContext.ApplicationUsers.Where(x => x.Id == userId).First();

            userdb.FavoriteCharacters.Add(character);
            await dbContext.SaveChangesAsync();
            
        }

        public ICollection<AnimeListViewModel> GetAnimesForCharacter(int id)
        {
            var animes = dbContext.Characters.Where(x => x.CharacterId == id).Include(x => x.Animes).FirstOrDefault().Animes.ToList();
            if(animes == null)
            {
                return null;
            }

            List<AnimeListViewModel> collection = new List<AnimeListViewModel>();
            foreach (var anime in animes)
            {
                var animeListModel = new AnimeListViewModel
                {
                    Id = anime.AnimeId,
                    ImageUrl = anime.ImageUrl,
                    Name = anime.Name,
                };
                collection.Add(animeListModel);
            }

            return collection;
        }

        public CharacterViewModel GetById(int id)
        {
            var character = dbContext.Characters.Where(x => x.CharacterId == id).Select(x => new CharacterViewModel
            {
                CharacterId = x.CharacterId,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Voice = x.Voice,
                Details = x.Details

            }).FirstOrDefault();
            
            return character;
        }

        //public Character GetCharacter(int id)
        //{
        //     var character = dbContext.Characters.Where(x => x.CharacterId == id).FirstOrDefault();

        //    return character;

        }
    }

