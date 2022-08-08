
namespace AnimePlace.Models
{
    public class Studio
    {
        public Studio()
        {
            this.Animes = new HashSet<Anime>();
        }

        public int StudioId { get; set; }

        public string Name { get; set; }

        public ICollection<Anime> Animes { get; set; }
    }

}