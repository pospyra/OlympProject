using AppServices.IRepository;
using Contracts;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.AnimalType
{
    public class AnimalTypeService : IAnimalTypeService
    {
        public readonly IAnimalTypeRepository _animalTypeRepository;

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository) 
        {
            _animalTypeRepository = animalTypeRepository; 
        }   

        public async Task<InfoAnimalTypeResponse> GetInfoAnimalType(long id)
        {
            var animalType = await _animalTypeRepository.GetAnimalTypeById(id);

            InfoAnimalTypeResponse typeRes= null;
            if (animalType == null)
                return typeRes;

            return typeRes = new InfoAnimalTypeResponse()
            {
                Id = animalType.Id,
                Type = animalType.Type
            };
        }
    }
}
