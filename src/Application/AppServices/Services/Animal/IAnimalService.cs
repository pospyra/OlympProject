using Contracts.Animal;
using Contracts.AnimalDto;
using Contracts.AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Animal
{
    public interface IAnimalService
    {
        public Task<InfoAnimalResponse> GetAnimalById(long id);

        public Task<IReadOnlyCollection<InfoAnimalResponse>> GetAnimalByFillters(DateTime startDateTime, DateTime endDateTime, int chipperId, long chippingLocationId, string lifeStatus, string gender, int from, int size);

        public Task<InfoAnimalResponse> AddAnimal(AddAnimalRequest request);

        public Task DeleteAnimal(long id);

        public Task<InfoAnimalResponse> EditAnimal(long Id, UpdateAnimalRequest request);
    }
}
