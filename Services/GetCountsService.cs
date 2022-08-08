using AnimePlace.Data;
using AnimePlace.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimePlace.Services
{
    public class GetCountsService : IGetCountsService
    {
        public readonly ApplicationDbContext Context;

        public GetCountsService(ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }

        
        
        public IndexViewModel GetCounts()
        {
                     
            var data = new IndexViewModel
            {
                AnimesCount = Context.Animes.Count(),
                CharactersCount = Context.Characters.Count(),
                StudiosCount = Context.Studios.Count(),
                GenresCount = Context.Genres.Count(),
            };

            return data;
            
        }
        
    }
}
