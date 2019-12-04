using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Models;

    public class AnimalCrossingContxtApi2 : DbContext
    {
        public AnimalCrossingContxtApi2 (DbContextOptions<AnimalCrossingContxtApi2> options)
            : base(options)
        {
        }

        public DbSet<AnimalCrossing.Models.Cat> Cat { get; set; }
    }
