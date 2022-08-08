namespace AnimePlace.Models
{
    public class PlanToWatchList : List
    {
        public PlanToWatchList()
        {
            this.PlanToWatchAnimeList = new HashSet<Anime>();
        }

        public int? PlanToWatchListId { get; set; }

        public ICollection<Anime> PlanToWatchAnimeList { get; set; }

    }
}
