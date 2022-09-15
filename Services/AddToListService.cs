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

        public async Task<string> CheckUserList(int id, string userId)
        {
            string response = await this.GetAnimeInListStatusAsync(id, userId, null);

            return response;
        }

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

                if(list == null)
                {
                    return result;
                }

                user.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Remove(anime);
            }
            else if (user.CompletedWatchList.CompletedAnimes.Contains(anime))
            {
                result = "Completed";

                if (list == null)
                {
                    return result;
                }

                user.CompletedWatchList.CompletedAnimes.Remove(anime);
            }
            else if (user.PlanToWatchList.PlanToWatchAnimeList.Contains(anime))
            {
                result = "Plan To Watch";

                if (list == null)
                {
                    return result;
                }

                user.PlanToWatchList.PlanToWatchAnimeList.Remove(anime);
            }
            else
            {
                result = "none";

                if (list == null)
                {
                    return result;
                }
            }

            if(list == "watching")
            {
                user.CurrentlyWatchingList.CurrentlyWatchingAnimesList.Add(anime);
            }
            else if (list == "completed")
            {
                user.CompletedWatchList.CompletedAnimes.Add(anime);
            }
            else if (list == "Plan To Watch")
            {
                user.PlanToWatchList.PlanToWatchAnimeList.Add(anime);
            }

            await dbContext.SaveChangesAsync();

            return result;
        }
    }
}
