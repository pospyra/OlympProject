using AppServices.IRepository;
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

        public async Task<Domain.Account> GetAccountById(int id)
        {
            return await _accountRepository.GetAccountById(id);
        }
    }
}
