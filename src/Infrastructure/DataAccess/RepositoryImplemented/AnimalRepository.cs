using AppServices.IRepository;
using Contracts;
using Domain;
using Infrastructure.Repositoty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImplemented
{
    public class AnimalRepository : IAnimalRepository
    {
        public readonly IBaseRepository<Animal> _baseRepository;

        public AnimalRepository(IBaseRepository<Animal> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task DeleteAnimal(Animal account)
        {
            await _baseRepository.DeleteAsync(account);
        }

        public async Task EditAnimal(Animal model)
        {
            await _baseRepository.UpdateAsync(model);
        }

        public IQueryable<Animal> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<IReadOnlyCollection<Animal>> GetAllAnimal()
        {
            return await _baseRepository.GetAll()
                .Select(a=>new Animal
                {
                    Id= a.Id,
                    Weihgt= a.Weihgt,
                    Length= a.Length,
                    Height= a.Height,
                    Gender= a.Gender,
                    LifeStatus= a.LifeStatus,
                    ChippingDateTime= a.ChippingDateTime,
                    ChipperId= a.ChipperId,
                    ChippingLocationId= a.ChippingLocationId,
                    DeathDateTime= a.DeathDateTime
                }).ToListAsync();
        }

        public async Task<Animal> GetAnimalById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public Task AddAnimal(Animal model)
        {
            return _baseRepository.AddAsync(model);
        }
    }
}
