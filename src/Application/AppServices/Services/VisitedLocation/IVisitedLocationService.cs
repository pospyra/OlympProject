using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.VisitedLocation
{
    public interface IVisitedLocationService
    {
        public Task<IReadOnlyCollection<VisitedLocationResponse>> GetVisitedLocation(long animalId, DateTime startDateTime, DateTime endDateTime, int from, int size);
    }
}
