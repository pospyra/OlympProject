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
            CreateMap<AnimalType, InfoTypeNameResponse>().ReverseMap();
            CreateMap<AddOrUpdateTypeRequest, InfoTypeNameResponse>().ReverseMap();
            CreateMap<AnimalType, AddOrUpdateTypeRequest>().ReverseMap();
        }
    }
}
