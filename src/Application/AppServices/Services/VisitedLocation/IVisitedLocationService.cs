using Contracts.VisitedLocationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.VisitedLocation
{
    public interface IVisitedLocationService
    {

        public Task<VisitedLocationResponse> AddVisitedLocation(long animalId, long pointId);

        public Task<VisitedLocationResponse> EditVisitedLocation(long animalId, EditVisitedLocationRequest request);

        public Task DeleteVisitedPoint(long animalId, long visitedPoint);

        public Task<IReadOnlyCollection<VisitedLocationResponse>> GetVisitedLocation(long animalId, DateTime startDateTime, DateTime endDateTime, int from, int size);
    }
}
