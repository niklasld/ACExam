using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCrossing.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.Models.ViewModels
{
    public class CatDateRepository : ICatDateRepository
    {
        private readonly AnimalCrossingContext _context;


        public CatDateRepository(AnimalCrossingContext context)
        {
            this._context = context;
        }

        public List<CatDate> Get()
        {

            return _context.CatDate.Include(x=>x.HostCat).Include(c=>c.GuestCat).ToList();

        }

    }
}
