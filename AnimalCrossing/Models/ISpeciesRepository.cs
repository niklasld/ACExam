using System;
using System.Collections.Generic;

namespace AnimalCrossing.Models
{
    public interface ISpeciesRepository
    {
        public List<Species> Get();
        public void Save(Species s);
        public Species Get(int speciesId);
        public void Delete(int speciesId);


    }
}
