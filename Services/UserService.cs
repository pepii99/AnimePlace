using AnimePlace.Data;
using AnimePlace.Models;
using AnimePlace.Services.Contracts;

namespace AnimePlace.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationUser GetUser(string userId)
        {
            return this.dbContext.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}
