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

        public async Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from, int size)
        {
            var query =_baseRepository.GetAll();
            int skip = 0;
            int take = 10;

            if(from >= 0)
                skip = from;

            if(size > 0)
                take = size;

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(x => x.FirstName.ToLower() == firstName.ToLower());

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(x => x.LastName.ToLower() == lastName.ToLower());

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email == email);

            return await query.Select(p => new InfoAccountResponse
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,    
            }).OrderByDescending(p=> p.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
