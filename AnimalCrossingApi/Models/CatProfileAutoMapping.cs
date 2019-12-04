using System;
using AnimalCrossing.Models.ViewModels;
using AutoMapper;

namespace AnimalCrossingApi.Models
{
    public class CatProfileAutoMapping : Profile
    {
        public CatProfileAutoMapping()
        {

            CreateMap<CatProfileAutoMapping, CatVm>();
        }
    }
}
