using Contracts;
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
    }
}
