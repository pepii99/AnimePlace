
namespace AnimePlace.Models
{
 

    public class Anime
    {
        
        public Anime()
        {
            this.Characters = new HashSet<Character>();
            this.Genres = new HashSet<Genre>();
            this.Studios = new HashSet<Studio>();
            this.ApplicationUsers = new HashSet<ApplicationUser>();
            this.CompletedWatchLists = new HashSet<CompletedWatchList>();
            
        }

        public int AnimeId { get; set; }

        public string? Name { get; set; }

        public string? AlternativeName { get; set; }

        public string? Sypnosis { get; set; }

        //public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }

        public string BorderImageUrl { get; set; }

        public double Score { get; set; }

        public int Favorites { get; set; }

        public int? Episodes { get; set; }

        public string Type { get; set; }

        public string Rating { get; set; }

        public string Source { get; set; }

        public string Status { get; set; }

        public string Aired { get; set; }

        public int? RelatedAnimeId { get; set; }

        public virtual Anime RelatedAnime { get; set; }

        public ICollection<Studio> Studios { get; set; }

        public ICollection<Character> Characters { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ICollection<CompletedWatchList> CompletedWatchLists { get; set; }

        public ICollection<PlanToWatchList> PlanToWatchLists { get; set; }

        public ICollection<CurrentlyWatchingList> CurrentlyWatchingLists { get; set; }

        

    }
}
