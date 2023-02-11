using Contracts.Account;
using Contracts.AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.AnimalType
{
    public interface IAnimalTypeService
    {
       public Task<InfoAnimalTypeResponse> GetInfoAnimalType(long id);

        public Task<InfoAnimalTypeResponse> AddType(AddOrUpdateTypeRequest requestType);

        public Task DeleteType(long id);

        public Task<InfoAnimalTypeResponse> EditType(long Id, AddOrUpdateTypeRequest requestType);
    }
}
