using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IAnimalTypeRepository
    {
        public Task<AnimalType> GetAnimalTypeById(long id);

        IQueryable<AnimalType> GetAll();

        public Task AddType(AnimalType model);

        public Task EditType(AnimalType model);

        public Task DeleteType(AnimalType model);
    }
}
