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
    public class AnimalVisitedLocationRepository : IAnimalVisitedLocationRepository
    {
        public readonly IBaseRepository<AnimalVisitedLocation> _baseRepository;

        public AnimalVisitedLocationRepository(IBaseRepository<AnimalVisitedLocation> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<AnimalVisitedLocation> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<AnimalVisitedLocation> GetById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
