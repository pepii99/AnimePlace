namespace AnimePlace.Models.ViewModels
{
    public class AnimesListViewModel : PagingViewModel
    {
        public IEnumerable<AnimeListViewModel> Animes { get; set; }

    }
}
