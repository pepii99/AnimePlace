using AnimePlace.Models;

namespace AnimePlace.Models
{
    public class CompletedWatchList : List
    {
        public CompletedWatchList()
        {
            this.CompletedAnimes = new HashSet<Anime>();
        }

        public int? CompletedWatchListId { get; set; }

        public ICollection<Anime> CompletedAnimes { get; set; }
       
    }
}
