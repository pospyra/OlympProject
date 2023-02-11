using AutoMapper;
using Contracts.LocationPoint;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.MappingProfile
{
    public class LocationPointMapProfile : Profile
    {
        public LocationPointMapProfile() 
        { 
            CreateMap<LocationPoint, InfoLocationPointResponse>().ReverseMap();
            CreateMap<InfoLocationPointResponse, AddOrUpdatePointRequest>().ReverseMap();
            CreateMap<LocationPoint, AddOrUpdatePointRequest>().ReverseMap();
        }

    }
}
