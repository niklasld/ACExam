using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCrossing.Data;

namespace AnimalCrossing.Models.ViewModels
{
    public class CatDateRepository : ICatDateRepository
    {
        private readonly AnimalCrossingContext _context;

        public List<CatDate> Get()
        {

            return _context.CatDate.ToList();

        }

        public CatDateRepository()
        {
        }
    }
}
