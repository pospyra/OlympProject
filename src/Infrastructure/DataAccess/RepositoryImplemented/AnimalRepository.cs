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

        public async Task<Animal> GetAnimalById(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
