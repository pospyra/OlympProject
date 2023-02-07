using AppServices.IRepository;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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

        public async Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from, int size)
        {
            return await _accountRepository.GetAccountByFillters(firstName, lastName, email, from, size);
        }

        public async Task<InfoAccountResponse> GetAccountById(int id)
        {
            var account = await _accountRepository.GetAccountById(id);

            InfoAccountResponse res = null;
            if (account == null)
                return res;

            return res = new InfoAccountResponse()
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email
            };
        }

    }
}
