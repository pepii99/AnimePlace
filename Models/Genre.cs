namespace AnimePlace.Models
{
    public class Genre
    {

        public Genre()
        {
            this.Animes = new HashSet<Anime>();
        }

        public int GenreId { get; set; }

        public string? Name { get; set; }

        public ICollection<Anime> Animes { get; set; }
    }

}