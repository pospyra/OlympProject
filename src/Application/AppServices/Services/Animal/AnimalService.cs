using AppServices.IRepository;
using Contracts.Animal;
using Infrastructure.Repositoty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppServices.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        public readonly IAnimalRepository _animalRepository;

        public AnimalService( IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<IReadOnlyCollection<InfoAnimalResponse>> GetAnimalByFillters(DateTime startDateTime, DateTime endDateTime, int chipperId, long chippingLocationId, string lifeStatus, string gender, int from, int size)
        {
            var animals = _animalRepository.GetAll();

            if (startDateTime != null)
                animals = animals.Where(x => x.ChippingDateTime >= startDateTime);

            if (endDateTime != null)
                animals = animals.Where(x => x.ChippingDateTime <= endDateTime);

            if (chipperId != null)
                animals = animals.Where(x => x.ChipperId == chipperId);

            if(chippingLocationId != null)
                animals = animals.Where(x => x.ChippingLocationId == chippingLocationId);

            if (!string.IsNullOrEmpty(lifeStatus))
                animals = animals.Where(x => x.LifeStatus.ToLower().Contains(lifeStatus.ToLower()));

            if (!string.IsNullOrEmpty(gender))
                animals = animals.Where(x => x.Gender.ToLower().Contains(gender.ToLower()));

            return await animals.Select(x => new InfoAnimalResponse()
            {
                Id= x.Id,
                Weihgt= x.Weihgt,
                Length= x.Length,
                Height  = x.Height,
                Gender  = x.Gender,
                LifeStatus= x.LifeStatus,
                ChippingDateTime= x.ChippingDateTime,
                ChipperId= x.ChipperId,
                ChippingLocationId= x.ChippingLocationId,
                DeathDateTime= x.DeathDateTime,

            }).OrderBy(x=> x.Id).ToListAsync();
        }

        public async Task<InfoAnimalResponse> GetAnimalById(int id)
        {
            var animal = await _animalRepository.GetAnimalById(id);

            return new InfoAnimalResponse()
            {
                Id = animal.Id,
                Weihgt = animal.Weihgt,
                Length = animal.Length,
                Height = animal.Height,
                Gender = animal.Gender,
                LifeStatus = animal.LifeStatus,
                ChippingDateTime = animal.ChippingDateTime,
                ChipperId = animal.ChipperId,
                ChippingLocationId = animal.ChippingLocationId,
                DeathDateTime = animal.DeathDateTime
            };
        }
    }
}
