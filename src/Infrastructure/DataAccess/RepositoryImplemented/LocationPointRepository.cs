using AppServices.IRepository;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImplemented
{
    public class LocationPointRepository : ILocationPointRepository
    {
        public readonly IBaseRepository<LocationPoint> _baseRepository;

        public LocationPointRepository(IBaseRepository<LocationPoint> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddPoint(LocationPoint locationPoint)
        {
            return _baseRepository.AddAsync(locationPoint);
        }

        public async Task DeletePoint(LocationPoint locationPoint)
        {
            await _baseRepository.DeleteAsync(locationPoint);
        }

        public async Task EditPoint(LocationPoint locationPoint)
        {
            await _baseRepository.UpdateAsync(locationPoint);
        }

        public IQueryable<LocationPoint> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<LocationPoint> GetLocationyPointById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
