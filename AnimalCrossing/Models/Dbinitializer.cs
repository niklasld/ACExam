using System;
using System.Linq;
using AnimalCrossing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalCrossing.Models
{
    public class Dbinitializer
    {

        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new AnimalCrossingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AnimalCrossingContext>>()))


            // look for any species
            if (!context.Species.Any())
            {
                var species = new Species[] {
                    new Species { Name = "Sphynx", Description = "A species of cat that has no fur because of selective breeding starting in the 1960s" },
                    new Species { Name = "Black-footed cat", Description = "Smallest african cat and it has black spots" }

                };
          

            foreach (Species s in species)
            {
                context.Species.Add(s);
            }
            context.SaveChanges();
            

            var speciesType = context.Species.ToList();
            var cats = new Cat[]
            
            {
                new Cat{ Name="McMittens", Gender= Gender.Male, BirthDate= DateTime.Parse("2018-10-12"), ProfilePicture="http://www.karoocats.org/application/storage/image/resize/blackfooted_cat_16.jpg", Description="Mcmittens likes catnip and female cats without fur", SpeciesId=speciesType[0].SpeciesId },
                new Cat{ Name="zoe", Gender= Gender.Female, BirthDate= DateTime.Parse("2017-05-05"), ProfilePicture="https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555382975/shape/mentalfloss/sphinxhed.png", Description="Fur less cat with no interest in plants", SpeciesId=speciesType[0].SpeciesId }
            };
            foreach (Cat c in cats)
            {
                context.Cats.Add(c);
            }
            context.SaveChanges();
        }

     }
        public Dbinitializer()
        {
        }
    }
}
