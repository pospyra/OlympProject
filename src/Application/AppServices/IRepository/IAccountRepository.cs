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
        public Task<Account> GetAccountById(int id);

    }
}
