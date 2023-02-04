using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Account
{
    public interface IAccountService
    {
        public Task<Domain.Account> GetAccountById(int id);
    }
}
