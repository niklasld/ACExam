using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalCrossing.Models.ViewModels
{
    public class ViewModelCreator
    {

        public static CatDetailsView CreateAnimalCatVm(ISpeciesRepository speciesRepository)
        {
            return new CatDetailsView()
            {
                cat = new Cat(),
                speciesList = new SelectList(speciesRepository.Get(), "SpeciesId", "Name")
            };

        }


        public static CatDetailsView EditAnimalCatVm(ISpeciesRepository speciesRepository, Cat c)
        {
            return new CatDetailsView()
            {
                cat = c,
                speciesList = new SelectList(speciesRepository.Get(), "SpeciesId", "Name")
            };

        }

        public static CateDateVM CreateCatDate (ICatDateRepository catDateRepository) {

            return new CateDateVM()
            {
                cat = new Cat(),
                CatList = new SelectList(catDateRepository.Get(), "CatId", "Name")

                
               


            };
            
        }

        public ViewModelCreator()
        {
        }

    }
}
