using AutoMapper;
using Contracts.AnimalType;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class TypeNamePrifile : Profile
    {
        public TypeNamePrifile() 
        {
            CreateMap<TypeName, InfoTypeNameResponse>().ReverseMap();
            CreateMap<AddOrUpdateTypeRequest, InfoTypeNameResponse>().ReverseMap();
            CreateMap<TypeName, AddOrUpdateTypeRequest>().ReverseMap();
        }
       
    }
}
