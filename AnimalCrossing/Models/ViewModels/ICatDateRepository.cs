using System;
using System.Collections.Generic;

namespace AnimalCrossing.Models.ViewModels
{
    public interface ICatDateRepository
    {
        public List<CatDate> Get();
        public void Save(CatDate cd);
        public CatDate Get(int CatDateId);
        public void Delete(int CatDateId);
    }
}
