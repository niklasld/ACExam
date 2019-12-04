using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalCrossing.Models
{
    public class CatDetailsView
    {
        public CatDetailsView()
        {
        }

        public Cat cat { get; set; }
        public SelectList speciesList { get; set; }
    }
}
