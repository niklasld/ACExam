using System;
using System.Collections.Generic;

namespace AnimalCrossing.Models.ViewModels
{
    public interface ICatDateRepository
    {
        public List<CatDate> Get();
    }
}
