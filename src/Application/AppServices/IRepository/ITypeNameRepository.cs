using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface ITypeNameRepository
    {
        public Task<TypeName> GetTypeNameById(long id);

        IQueryable<TypeName> GetAll();

        public Task AddTypeName(TypeName model);

        public Task EditTypeName(TypeName model);

        public Task DeleteTypeName(TypeName model);
    }
}
