using AppServices.IRepository;
using Domain;
using Infrastructure.BaseRepositoty;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImplemented
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {
        public readonly IBaseRepository<AnimalType> _baseRepository;

        public AnimalTypeRepository(IBaseRepository<AnimalType> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddType(AnimalType model)
        {
           return _baseRepository.AddAsync(model);
        }

        public async  Task DeleteType(AnimalType model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditType(AnimalType model)
        {
            await _baseRepository.UpdateAsync(model);
        }

        public IQueryable<AnimalType> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<AnimalType> GetAnimalTypeById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

    }
}
