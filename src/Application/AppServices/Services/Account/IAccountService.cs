using Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Account
{
    public interface IAccountService
    {
        public Task<InfoAccountResponse> GetAccountById(int id);

        public Task<IReadOnlyCollection<InfoAccountResponse>> GetAccountByFillters(string? firstName, string? lastName, string? email, int from, int size);

        public Task<InfoAccountResponse> RegisterAccount(RegisterOrUpdateRequest register);

        public Task DeleteAccount(int id);

        public Task<InfoAccountResponse> EditAccount(int accountId, RegisterOrUpdateRequest update);
    }
}
