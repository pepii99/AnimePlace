using AnimePlace.Models;
using AnimePlace.Models.InputModels;
using AnimePlace.Models.ViewModels;

namespace AnimePlace.Services.Contracts
{
    public interface IAnimesService
    {
        public Task CreateAsync(CreateAnimeInputModel input);

        public IEnumerable<AnimeListViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        public Task AddToFavorites(int id, string userId);

        public SingleAnimeViewModel GetById(int id);

        //public Task AddToCompletedWatchList(int id, string userId);

        //public Task AddToWatchingList(int id, string userId);

        public ICollection<CharacterViewModel> GetAllForAnime(int id);

        public Task EditAsync(EditAnimeInputModel input, int id);

        public EditAnimeInputModel GetEdit(int id);

        public Task Delete(int id);

        public List<Anime> GetRecommendations(int AnimeId);

    }
}
