namespace AnimePlace.Models.ViewModels
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)AnimesCount / AnimesPerPage);

        public int PreviousPageNumber => PageNumber - 1;

        public int NextPageNumber => PageNumber + 1;

        public int AnimesCount { get; set; }

        public int AnimesPerPage { get; set; }
    }
}
