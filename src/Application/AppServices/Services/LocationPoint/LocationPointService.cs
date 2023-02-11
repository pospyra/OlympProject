using AppServices.IRepository;
using AutoMapper;
using Contracts.LocationPoint;
using Domain;
using Microsoft.Win32;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.LocationPoint
{
    public class LocationPointService : ILocationPointService
    {
        public readonly ILocationPointRepository _locationPointRepository;
        public readonly IMapper _mapper;
        public LocationPointService(ILocationPointRepository locationPointReposirory, IMapper mapper) 
        {
            _locationPointRepository= locationPointReposirory;
            _mapper= mapper;
        }

        public async Task<InfoLocationPointResponse> AddLocation(AddOrUpdatePointRequest request)
        {
            var newLocation = _mapper.Map<Domain.LocationPoint>(request);

            var existingPoint = _locationPointRepository.GetAll().Where(x => x.Latitude == request.Latitude
            && x.Longitude == request.Longitude);
            //if (existingPoint != null)
            //    return null;

            await _locationPointRepository.AddPoint(newLocation);
            return _mapper.Map<InfoLocationPointResponse>(newLocation);
        }

        public async Task DeleteLocation(long id)
        {
            var existingLocation = await _locationPointRepository.GetLocationyPointById(id);
            await _locationPointRepository.DeletePoint(existingLocation);
        }

        public async Task<InfoLocationPointResponse> EditLocation(long id, AddOrUpdatePointRequest request)
        {
            var existingLocation = await _locationPointRepository.GetLocationyPointById(id);

            await _locationPointRepository.EditPoint(_mapper.Map(request, existingLocation));

            return _mapper.Map<InfoLocationPointResponse>(request);
        }

        public async  Task<InfoLocationPointResponse> GetLocationPointById(long id)
        {
            var locationPoint = await _locationPointRepository.GetLocationyPointById(id);
            InfoLocationPointResponse pointRes = null;
            if (locationPoint == null)
                return pointRes;

            return _mapper.Map<InfoLocationPointResponse>(locationPoint);
        }
    }
}
