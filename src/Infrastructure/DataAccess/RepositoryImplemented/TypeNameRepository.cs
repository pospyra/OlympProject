using AppServices.IRepository;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImplemented
{
    public class TypeNameRepository : ITypeNameRepository
    {
        public readonly IBaseRepository<TypeName> _baseRepository;

        public TypeNameRepository(IBaseRepository<TypeName> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task AddTypeName(TypeName model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteTypeName(TypeName model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditTypeName(TypeName model)
        {
            await _baseRepository.UpdateAsync(model);
        }

        public IQueryable<TypeName> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<TypeName> GetTypeNameById(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
