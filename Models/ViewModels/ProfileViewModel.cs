namespace AnimePlace.Models.ViewModels
{
    public class ProfileViewModel
    {
        public int? Id { get; set; }

        public string? Username { get; set; }

        public ICollection<FavoriteCharacterViewModel>? FavoriteCharacters { get; set; }

        public ICollection<FavoriteAnimeViewModel>? FavoriteAnimes { get; set; }

        public ICollection<CompletedWatchListViewModel>? CompletedWatchListView { get; set; }

        public ICollection<CurrentlyWatchingListViewModel>? CurrentlyWatchingListView { get; set; }

        public ICollection<PlanToWatchListViewModel>? PlanToWatchListView { get; set; }

    }
}
