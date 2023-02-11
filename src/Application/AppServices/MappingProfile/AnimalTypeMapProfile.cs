﻿using AutoMapper;
using Contracts.AnimalType;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class AnimalTypeMapProfile : Profile
    {
        public AnimalTypeMapProfile()
        { 
            CreateMap<AnimalType, InfoAnimalTypeResponse>().ReverseMap();
            CreateMap<AddOrUpdateTypeRequest, InfoAnimalTypeResponse>().ReverseMap();
            CreateMap<AnimalType, AddOrUpdateTypeRequest>().ReverseMap();
        }
    }
}
