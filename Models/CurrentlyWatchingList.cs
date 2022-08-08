namespace AnimePlace.Models
{
    public class CurrentlyWatchingList : List
    {
        public CurrentlyWatchingList()
        {
            this.CurrentlyWatchingAnimesList = new HashSet<Anime>();
        }

        public int? CurrentlyWatchingListId { get; set; }

        public ICollection<Anime> CurrentlyWatchingAnimesList { get; set; }

    }
}