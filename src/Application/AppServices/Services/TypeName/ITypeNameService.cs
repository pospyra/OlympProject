using Contracts.Account;
using Contracts.AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.AnimalType
{
    public interface ITypeNameService
    {
       public Task<InfoTypeNameResponse> GetInfoAnimalType(long id);

        public Task<InfoTypeNameResponse> AddType(AddOrUpdateTypeRequest requestType);

        public Task DeleteType(long id);

        public Task<InfoTypeNameResponse> EditType(long Id, AddOrUpdateTypeRequest requestType);
    }
}
