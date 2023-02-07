using AppServices.IRepository;
using Contracts;
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

        public VisitedLocationService(IAnimalVisitedLocationRepository animalVisitedLocationRepository) 
        {
            _visitedLocationRepository= animalVisitedLocationRepository;
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
