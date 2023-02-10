using AppServices.IRepository;
using Contracts;
using Domain;
using Infrastructure.Repositoty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public IQueryable<Account> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
