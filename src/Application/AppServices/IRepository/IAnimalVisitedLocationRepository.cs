using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IAnimalVisitedLocationRepository
    {
        public IQueryable<AnimalVisitedLocation> GetAll();

        public Task<AnimalVisitedLocation> GetById(long id);

        public Task AddVisitedLocation(AnimalVisitedLocation visitedLocation);

        public Task DeleteVisitedLocation(AnimalVisitedLocation visitedLocation);

        public Task UpdateVisitedLocation(AnimalVisitedLocation visitedLocation);
    }
}
