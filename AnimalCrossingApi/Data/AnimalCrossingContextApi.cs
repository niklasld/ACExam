using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Models;

    public class AnimalCrossingContextApi : DbContext
    {
        public AnimalCrossingContextApi (DbContextOptions<AnimalCrossingContextApi> options)
            : base(options)
        {
        }

        public DbSet<AnimalCrossing.Models.Cat> Cat { get; set; }
    }
