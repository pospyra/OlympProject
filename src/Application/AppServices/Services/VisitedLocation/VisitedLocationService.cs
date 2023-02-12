using AppServices.IRepository;
using AutoMapper;
using Contracts.VisitedLocationDto;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.VisitedLocation
{
    public class VisitedLocationService : IVisitedLocationService
    {
        public readonly IAnimalVisitedLocationRepository _visitedLocationRepository;
        public readonly IMapper _mapper;

        public VisitedLocationService(IAnimalVisitedLocationRepository animalVisitedLocationRepository, IMapper mapper) 
        {
            _visitedLocationRepository= animalVisitedLocationRepository;
            _mapper= mapper;
        }

        public async Task<VisitedLocationResponse> AddVisitedLocation(long animalId, long pointId)
        {
            var newVisitedLocation = new AnimalVisitedLocation()
            {
                AnimalId = animalId,
                PointId = pointId,
                DateTimeOfVisitLocationPoint = DateTime.UtcNow
            };
            await _visitedLocationRepository.AddVisitedLocation(newVisitedLocation);

            return new VisitedLocationResponse()
            {
                Id = newVisitedLocation.Id,
                PointId = newVisitedLocation.PointId,
                DateTimeOfVisitLocationPoint = DateTime.UtcNow
            };
            //return _mapper.Map<VisitedLocationResponse>(newVisitedLocation);
        }

        public async Task DeleteVisitedPoint(long animalId, long visitedPointId)
        {
            var delVisPoint = await _visitedLocationRepository.GetById(visitedPointId);
            await _visitedLocationRepository.DeleteVisitedLocation(delVisPoint);
        }

        public async  Task<VisitedLocationResponse> EditVisitedLocation(long animalId, EditVisitedLocationRequest request)
        {
            var existingVisLocation = await _visitedLocationRepository.GetById(animalId);

            await _visitedLocationRepository.UpdateVisitedLocation(_mapper.Map(request, existingVisLocation));

            return _mapper.Map<VisitedLocationResponse>(request);
        }

        public async Task<IReadOnlyCollection<VisitedLocationResponse>> GetVisitedLocation(long animalId, DateTime startDateTime, DateTime endDateTime, int from, int size)
        {
            var visitedLocation = _visitedLocationRepository.GetAll().Where(x => x.AnimalId == animalId);
           
            int skip = 0;
            int take = 10;
            if (from >= 0)
                skip = from;
            if (size > 0)
                take = size;

            if (endDateTime != null)
                visitedLocation = visitedLocation.Where(x=>x.DateTimeOfVisitLocationPoint <= endDateTime);

            if (startDateTime != null)
                visitedLocation = visitedLocation.Where(x => x.DateTimeOfVisitLocationPoint >= startDateTime);

            return await visitedLocation.Select(x => new VisitedLocationResponse()
            {
                Id= x.Id,            
                DateTimeOfVisitLocationPoint= x.DateTimeOfVisitLocationPoint,
                PointId = x.PointId
            }).OrderBy(x=>x.DateTimeOfVisitLocationPoint).Skip(skip).Take(take).ToListAsync();

        }
    }
}
