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
    public class AccountRepository : IAccountRepository
    {
        private readonly IBaseRepository<Account> _baseRepository;

        public AccountRepository(IBaseRepository<Account> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Account> GetAccountById(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
