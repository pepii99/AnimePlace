namespace AnimePlace.Services.Contracts
{
    public interface IAddToListService
    {
        //Checks in which list, if any, the anime is in, in order to remove it from the last list and add it into the newer list
        public Task<string> GetAnimeInListStatusAsync(int id, string userId, string list);

        public Task<string> CheckUserList(int id, string userId);

        //public Task AddAnimeToWatchingList(int id, string userId);

        //public Task AddAnimeToCompletedList(int id, string userId);

        //public Task AddAnimeToPlanToWatchList(int id, string userId);
    }
}
