using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;
using AnimePlace.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimePlace.Services
{
    public class AnimesService : IAnimesService
    {
        private readonly ApplicationDbContext dbContext;

        public IUserService UserService { get; }

        public AnimesService(ApplicationDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            UserService = userService;
        }

        //Creates the anime
        public async Task CreateAsync(CreateAnimeInputModel input)
        {

            var anime = new Anime()
            {
                Name = input.Name,
                AlternativeName = input.AlternativeName,
                Sypnosis = input.Sypnosis,
                Type = input.Type.ToString(),
                Episodes = input.Episodes,
                ImageUrl = input.ImageUrl,
                BorderImageUrl = input.BorderImageUrl,
                Source = input.Source,
                Status = input.Status,
                Aired = input.Aired,
            };

            if(!dbContext.Animes.Any(x => x.Name == anime.Name))
            {
                await dbContext.Animes.AddAsync(anime);
            }

            await dbContext.SaveChangesAsync();
        }

        //Gets the Edit (view) page of an anime
        public EditAnimeInputModel GetEdit(int id)
        {
            var anime = dbContext.Animes.Find(id);

            var viewModel = new EditAnimeInputModel()
            {
                Name = anime.Name,
                AlternativeName = anime.AlternativeName,
                Episodes = anime.Episodes,
                ImageUrl = anime.ImageUrl,
                Sypnosis = anime.Sypnosis,
                BorderImageUrl = anime.BorderImageUrl,
                Rating = anime.Rating,
                Aired = anime.Aired,
                Status = anime.Status,
                Source = anime.Source,
            };

            return viewModel;
        }

        // Updates the anime information based on the inputi in the Edit page
        public async Task EditAsync(EditAnimeInputModel input, int id)
        {
            var anime = await dbContext.Animes.FindAsync(id);

            if (anime == null)
            {
                return;
            }

            anime.Name = input.Name;
            anime.AlternativeName = input.AlternativeName;
            anime.Episodes = input.Episodes;
            anime.Sypnosis = input.Sypnosis;
            anime.ImageUrl = input.ImageUrl;
            anime.BorderImageUrl = input.BorderImageUrl;
            anime.Aired = input.Aired;
            anime.Source = input.Source;
            anime.Status = input.Status;
            anime.Rating = input.Rating;

            dbContext.Animes.Update(anime);

            await dbContext.SaveChangesAsync();
        }

        //Deletes the anime
        public async Task Delete(int id)
        {
            var anime = await dbContext.Animes.FindAsync(id);

            dbContext.Animes.Remove(anime);

            await dbContext.SaveChangesAsync();
        }

        // Gets all the animes (work to be done)
        public IEnumerable<AnimeListViewModel> GetAll(int page = 2, int itemsPerPage = 30)
        {
            //.Skip((page -1) * itemsPerPage).Take(itemsPerPage);
            var result = dbContext.Animes.ToList().OrderByDescending(x => x.Favorites)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new AnimeListViewModel
                {
                    Id = x.AnimeId,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                });

            return result;
        }

        
        public async Task AddToFavorites(int id, string userId)
        {
            var anime = await dbContext.Animes.FindAsync(id);

            var user = this.UserService.GetUser(userId);

            user?.FavoriteAnimes.Add(anime);
            await dbContext.SaveChangesAsync();
        }

        // Gets recommendations (more work to be done here)
        public List<Anime> GetRecommendations(int AnimeId)
        {
            var animeGenres = dbContext.Animes.Include("Genres").Where(x => x.AnimeId == AnimeId).First().Genres.Select(x => x.Name).ToArray();
            var animes = dbContext.Animes.ToList();
            var allGenres = dbContext.Animes.Include("Genres").Select(x => x.Genres.Select(x => x.Name).ToList()).ToArray();
            var result = new List<Anime>();
            for (int i = 1; i <= allGenres.Length; i++)
            {
                if (allGenres[i].Count <= 0)
                {
                    break;
                }
                else
                {
                    if (animeGenres.Length == 0)
                    {
                        break;
                    }

                    if (animeGenres[0] == allGenres[i][0])
                    {
                        result.Add(animes[i]);
                    }
                }
                
            }
            
            return result;
        }

        // Here also big bug
        public SingleAnimeViewModel GetById(int id)
        {

            var reccomendedAnime = this.GetRecommendations(id);

            var animeQuery = this.GetQueryableAnime(id);

            //var test = animeQuery.Select(x => x).FirstOrDefault();

            var result = animeQuery.Select(x => new SingleAnimeViewModel
            {
                Id = id,
                Name = x.Name,
                AlternativeName = x.AlternativeName,
                Sypnosis = x.Sypnosis,
                ImageUrl = x.ImageUrl,
                BorderImageUrl = x.BorderImageUrl,
                Score = x.Score,
                Episodes = x.Episodes,
                Type = x.Type,
                Favorites = x.Favorites,
                Aired = x.Aired,
                Source = x.Source,
                Status = x.Status,
                Rating = x.Rating,
                
                RelatedAnime = new RelatedAnimeViewModel { 
                    
                AnimeId = x.RelatedAnime.AnimeId,
                AnimeName = x.RelatedAnime.Name },

                Genres = x.Genres.Select(x => new GenreViewModel { Name = x.Name }).ToList(),
                Recommendations = reccomendedAnime
                .Select(x => new RecommendationsViewModel { 
                    AnimeId = x.AnimeId,
                    AnimeImageUrl = x.ImageUrl, 
                    AnimeName = x.Name, 
                    AnimeRating = x.Score
                }).ToList()
                

            }).FirstOrDefault();

            return result;
        }

        public int GetCount()
        {
            return dbContext.Animes.Count();
        }

        public ICollection<CharacterViewModel> GetAllForAnime(int id)
        {

            var characters = this.GetQueryableAnime(id).Select(x => x.Characters).ToList();

            var result = characters.SelectMany(x => x);

            ICollection<CharacterViewModel> collection = new List<CharacterViewModel>();
            foreach (var item in result)
            {
                var characterViewModel = new CharacterViewModel
                {
                    CharacterId = item.CharacterId,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Voice = item.Voice,
                    Role = item.Role
                };
                collection.Add(characterViewModel);
            }

            return collection;
        }


        //public async Task AddToCompletedWatchList(int id, ApplicationUser user)
        //{
        //    var anime = this.GetAnime(id);
            
        //    var userDb = dbContext.ApplicationUsers.Where(x => x.Id == user.Id).Include(s => s.CompletedWatchList).ThenInclude(s => s.CompletedAnimes).FirstOrDefault();
            
        //    if (userDb.CompletedWatchList.CompletedAnimes.Contains(anime))
        //    {
        //        userDb.CompletedWatchList.CompletedAnimes.Remove(anime);
        //    }
        //    else
        //    {
        //        userDb.CompletedWatchList.CompletedAnimes.Add(anime);
        //    }


        //    await dbContext.SaveChangesAsync();
        //}

        //public async Task AddToWatchingList(int id, ApplicationUser user)
        //{
        //    //var anime = this.GetAnime(id);
        //    //var userDb = dbContext.CurrentlyWatchingLists.Where(x => x.ApplicationUserRef == user.Id).First();

        //    //if (userDb.CurrentlyWatchingAnimesList.Contains(anime))
        //    //{
        //    //    userDb.CurrentlyWatchingAnimesList.Remove(anime);
        //    //}
        //    //else
        //    //{
        //    //    userDb.CurrentlyWatchingAnimesList.Add(anime);
        //    //}

        //    await dbContext.SaveChangesAsync();

        //}

        public IQueryable<Anime> GetQueryableAnime(int id)
        {
            var queryableAnime = dbContext.Animes.Where(x => x.AnimeId == id);
            return queryableAnime;
        }

    }
}
