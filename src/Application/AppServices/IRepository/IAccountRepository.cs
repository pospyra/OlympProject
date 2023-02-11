using Contracts;
using Contracts.Account;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAll();

        public Task<Account> GetAccountById(int id);

        public Task Registration(Account model);

        public Task EditAccount(Account model);

        public Task DeleteAccount(Account account);

        //public Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from, int size);
    }
}
