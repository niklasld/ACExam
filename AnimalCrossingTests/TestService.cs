using System;
using System.Collections.Generic;
using AnimalCrossing.Models;

namespace AnimalCrossingTests
{
    public class TestService
    {

        public static List<Species> GetTestSpecies()
        {
            var species = new List<Species>();
            species.Add(new Species()
            {
                SpeciesId = 1,
                Name = "African Golden Cat",
                Description = "The African golden cat is a wild cat endemic to the rainforests of West and Central Africa",
            });
            species.Add(new Species()
            {
                SpeciesId = 2,
                Name = "Wildcat Cat",
                Description = "The wildcat is a species complex comprising two small wild cat species, the European wildcat and the African wildcat",
            });

            return species;
        }

        public TestService()
    {
    }
    }
}
