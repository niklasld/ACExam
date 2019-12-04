using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossingApi.Models
{


        public class AnimalCrossingApiContext : DbContext
        {
            public AnimalCrossingApiContext(DbContextOptions<AnimalCrossingApiContext> options)
                : base(options)
            {
            }

            public DbSet<AnimalCrossingApiContext> TodoItems { get; set; }
        }
}
