using AutoMapper;
using Contracts.Animal;
using Contracts.AnimalDto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class AnimalMapProfile : Profile
    {
        public AnimalMapProfile()
        {
            CreateMap<Animal, InfoAnimalResponse>().ReverseMap();
            CreateMap<Animal, AddAnimalRequest>().ReverseMap();
            CreateMap<InfoAnimalResponse, AddAnimalRequest>().ReverseMap();
            CreateMap<InfoAnimalResponse, UpdateAnimalRequest>().ReverseMap();
            CreateMap<Animal, UpdateAnimalRequest>().ReverseMap();
        }
    }
}
