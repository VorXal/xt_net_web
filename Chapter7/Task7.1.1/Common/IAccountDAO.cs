using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAccountDAO
    {
        void AddAcount(string login, string password);
        string[] GetAccountRoles(string login);
        Account GetAccountByLogin(string login);
        string[] GetRoles();
        List<Account> GetAllAccounts();
    }
}
