﻿using Contracts;
using Domain;
using Infrastructure.BaseRepositoty;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IAnimalRepository
    {
        public Task<Animal> GetAnimalById(long id);

        public Task<IReadOnlyCollection<Animal>> GetAllAnimal();

        IQueryable<Animal> GetAll();

        public Task AddAnimal(Animal model);

        public Task EditAnimal(Animal model);

        public Task DeleteAnimal(Animal account);
    }
}
