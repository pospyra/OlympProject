using AutoMapper;
using Contracts.VisitedLocationDto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class VisitedLocatiomMapProfile : Profile
    {
        public VisitedLocatiomMapProfile()
        {
            CreateMap<AnimalVisitedLocation, VisitedLocationResponse>().ReverseMap();
            CreateMap<EditVisitedLocationRequest, VisitedLocationResponse>().ReverseMap();
        }
    }
}
