using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        #region DbSets

        public DbSet<Actor> Actors { get; set; }
        
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        
        public DbSet<Cinema> Cinemas { get; set; }
        
        public DbSet<Producer> Producers { get; set; }

        #endregion
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     string connectionString =
        //         "Server=tcp:db-testing.database.windows.net,1433;Initial Catalog=eTesting;" +
        //         "Persist Security Info=False;User ID=yeview;Password=Pass4ik123;" +
        //         "MultipleActiveResultSets=False;Encrypt=True;" +
        //         "TrustServerCertificate=True;" +
        //         "Connection Timeout=30;";
        //
        //     optionsBuilder.UseSqlServer(connectionString);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
        
            modelBuilder.Entity<Actor_Movie>().HasOne(m
                => m.Movie).WithMany(am => am.Actors_Movies).
                HasForeignKey(m => m.MovieId);
            
            modelBuilder.Entity<Actor_Movie>().HasOne(m
                    => m.Actor).WithMany(am => am.Actors_Movies).
                HasForeignKey(m => m.ActorId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}