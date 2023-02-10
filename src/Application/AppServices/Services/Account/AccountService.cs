using AppServices.IRepository;
using AutoMapper;
using Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
        public readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from, int size)
        {
            var query = _accountRepository.GetAll();
            int skip = 0;
            int take = 10;

            if (from >= 0)
                skip = from;

            if (size > 0)
                take = size;

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(x => x.FirstName.ToLower() == firstName.ToLower());

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(x => x.LastName.ToLower() == lastName.ToLower());

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email == email);

            //return await query.Select(p => _mapper.Map<InfoAccountResponse>(p))
            //    .OrderByDescending(p => p.Id).Skip(skip).Take(take).ToListAsync();

            return await query.Select(p => new InfoAccountResponse()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
            }).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToListAsync();
        }


        public async Task<InfoAccountResponse> GetAccountById(int id)
        {
            var account = await _accountRepository.GetAccountById(id);

            InfoAccountResponse res = null;
            if (account == null)
                return res;

            return res = _mapper.Map<InfoAccountResponse>(account);
        }
    }
}
