using AnimePlace.Data;

namespace AnimePlace.Models.ViewModels
{
    public class SingleAnimeViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AlternativeName { get; set; }

        public string? Sypnosis { get; set; }

        public string? ImageUrl { get; set; }

        public string? BorderImageUrl { get; set; }

        public double Score { get; set; }

        public int Favorites { get; set; }

        public int? Episodes { get; set; }

        public string? Type { get; set; }

        public string? Source { get; set; }

        public string? Aired { get; set; }

        public string? Rating { get; set; }

        public string? Status { get; set; }

        public RelatedAnimeViewModel? RelatedAnime { get; set; }

        public ICollection<CharacterViewModel> Characters { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }

        public ICollection<RecommendationsViewModel> Recommendations { get; set; }
    }
}
