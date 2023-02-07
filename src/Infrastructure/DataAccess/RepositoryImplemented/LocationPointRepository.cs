using AppServices.IRepository;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<LocationPoint> GetLocationyPointById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
