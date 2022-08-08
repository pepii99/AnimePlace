
namespace AnimePlace.Models
{
    public class Character
    {
        public Character()
        {
            this.Animes = new HashSet<Anime>();
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }
        
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Details { get; set; }

        public string Role { get; set; }

        public string Voice { get; set; }

        public ICollection<Anime> Animes { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
