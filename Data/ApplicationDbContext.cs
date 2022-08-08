using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AnimePlace.Models.InputModels;
using AnimePlace.Models;

namespace AnimePlace.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<CompletedWatchList> CompletedWatchList { get; set; }

        public DbSet<CurrentlyWatchingList> CurrentlyWatchingLists { get; set; }

        public DbSet<PlanToWatchList> PlanToWatchLists { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.CurrentlyWatchingList)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<CurrentlyWatchingList>(b => b.ApplicationUserRef);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.CompletedWatchList)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<CompletedWatchList>(b => b.ApplicationUserRef);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.CurrentlyWatchingList)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<CurrentlyWatchingList>(b => b.ApplicationUserRef);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.PlanToWatchList)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<PlanToWatchList>(b => b.ApplicationUserRef);

            base.OnModelCreating(modelBuilder);
        }
    }

    


}