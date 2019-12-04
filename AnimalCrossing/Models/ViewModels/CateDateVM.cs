using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalCrossing.Models.ViewModels
{
    public class CateDateVM
    {

        public SelectList CatList { get; set; }
        public Cat cat { get; set; }


        public CateDateVM()
        {
        }
    }
}
