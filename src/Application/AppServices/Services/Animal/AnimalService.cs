using AppServices.IRepository;
using Contracts.Animal;
using Infrastructure.BaseRepositoty;
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
        public readonly IAnimalTypeRepository _animalTypeRepository;
        public readonly IAnimalVisitedLocationRepository _animalVisitedLocationRepository;

        public AnimalService( 
            IAnimalRepository animalRepository, 
            IAnimalTypeRepository animalTypeRepository,
            IAnimalVisitedLocationRepository animalVisitedLocationRepository)
        {
            _animalRepository = animalRepository;
            _animalTypeRepository = animalTypeRepository;
            _animalVisitedLocationRepository= animalVisitedLocationRepository;
        }
        public async Task<IReadOnlyCollection<InfoAnimalResponse>> GetAnimalByFillters(DateTime startDateTime, DateTime endDateTime, int chipperId, long chippingLocationId, string lifeStatus, string gender, int from, int size)
        {
            var animals = _animalRepository.GetAll();

            int skip = 0;
            int take = 10;
            if (from >= 0)
                skip = from;
            if (size > 0)
                take = size;

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

            }).OrderBy(x=> x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoAnimalResponse> GetAnimalById(long id)
        {
            var animal = await _animalRepository.GetAnimalById(id);

            InfoAnimalResponse animalRes = null;
            if (animal == null)
                return animalRes;

            var animalTypes = _animalTypeRepository.GetAll().Where(x => x.AnimalId == id).ToList();
            long[] animalTypesID;
            List<long> longsType = new List<long>();
            for (int i = 0; i <= animalTypes.Count; i++)
            {
                longsType.Add(animalTypes[i].Id);
            }
            animalTypesID = longsType.ToArray();


            var visitedLocation = _animalVisitedLocationRepository.GetAll().Where(x=>x.AnimalId == id).ToList();
            long[] visitedLocationID;
            List<long> longsVisitedLocarion = new List<long>();
            for (int i = 0; i <= visitedLocation.Count; i++)
            {
                longsVisitedLocarion.Add(visitedLocation[i].Id);
            }
            visitedLocationID = longsVisitedLocarion.ToArray();

            return animalRes = new InfoAnimalResponse()
            {
                Id = animal.Id,
                AnimalTypesId = animalTypesID,
                Weihgt = animal.Weihgt,
                Length = animal.Length,
                Height = animal.Height,
                LifeStatus = animal.LifeStatus,
                ChippingDateTime = animal.ChippingDateTime,
                ChipperId = animal.ChipperId,
                ChippingLocationId = animal.ChippingLocationId,
                VisitedLocations= visitedLocationID,
                DeathDateTime = animal.DeathDateTime,
            };
        }
    }
}
