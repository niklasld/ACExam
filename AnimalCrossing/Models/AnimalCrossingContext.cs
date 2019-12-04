using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Models;

namespace AnimalCrossing.Data
{
    public class AnimalCrossingContext : DbContext
    {
        public AnimalCrossingContext(DbContextOptions<AnimalCrossingContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<CatDate> CatDate { get; set; }
        public DbSet<CatReview> CaReviews { get; set; }

                    
    }
}


