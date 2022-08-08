using AnimePlace.Data;
using AnimePlace.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AnimePlace.Services
{
    public class AddToListService : IAddToListService
    {
        private readonly ApplicationDbContext dbContext;

        public AddToListService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public Task AddAnimeToCompletedList(int id, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddAnimeToPlanToWatchList(int id, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddAnimeToWatchingList(int id, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<string> GetAnimeInListStatusAsync(int id, string userId, string list)
        {
            
            string result = string.Empty;

            var user = this.dbContext.ApplicationUsers.Where(x => x.Id == userId)
                .Include(x => x.CurrentlyWatchingList)
                .ThenInclude(x => x.CurrentlyWatchingAnimesList)
                .Include(x => x.CompletedWatchList)
                .ThenInclude(x => x.CompletedAnimes)
                .Include(x => x.PlanToWatchList)
                .ThenInclude(x => x.PlanToWatchAnimeList)
                .FirstOrDefault();

            var anime = await dbContext.Animes.FindAsync(id);

            if (user.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Contains(anime))
            {
                result = "Watching";
                user.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Remove(anime);
            }
            else if (user.CompletedWatchList.CompletedAnimes.Contains(anime))
            {
                result = "Completed";
                user.CompletedWatchList.CompletedAnimes.Remove(anime);
            }
            else if (user.PlanToWatchList.PlanToWatchAnimeList.Contains(anime))
            {
                result = "PlanToWatch";
                user.PlanToWatchList.PlanToWatchAnimeList.Remove(anime);
            }
            else
            {
                result = "none";
            }

            if(list == "watching")
            {
                user.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Add(anime);
            }
            else if (list == "completed")
            {
                user.CompletedWatchList.CompletedAnimes.Add(anime);
            }
            else if (list == "planToWatch")
            {
                user.PlanToWatchList.PlanToWatchAnimeList.Add(anime);
            }

            await dbContext.SaveChangesAsync();

            return result;
        }
    }
}
