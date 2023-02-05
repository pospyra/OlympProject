using AppServices.IRepository;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Account
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from = 10, int size = 0)
        {
            return await _accountRepository.GetAccountByFillters(firstName, lastName, email, from, size);
        }

        public async Task<InfoAccountResponse> GetAccountById(int id)
        {
            var user =  await _accountRepository.GetAccountById(id);

            var res = new InfoAccountResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return res;
        }
    }
}
