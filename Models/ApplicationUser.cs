using Microsoft.AspNetCore.Identity;

namespace AnimePlace.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.FavoriteCharacters = new HashSet<Character>();
            this.FavoriteAnimes = new HashSet<Anime>();
            this.CompletedWatchList = new CompletedWatchList();
            this.CurrentlyWatchingList = new CurrentlyWatchingList();
            this.PlanToWatchList = new PlanToWatchList();
        }

        public ICollection<Character> FavoriteCharacters { get; set; }

        public ICollection<Anime> FavoriteAnimes { get; set; }
        
        public CompletedWatchList CompletedWatchList { get; set; }

        public PlanToWatchList PlanToWatchList { get; set; }

        public CurrentlyWatchingList CurrentlyWatchingList { get; set; }

    }
}
