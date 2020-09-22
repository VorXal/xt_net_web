using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class AccountManager : IAccountBLL
    {
        private readonly IAccountDAO _accountDAO;

        public AccountManager(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public void AddAcount(string login, string password)
        {
            _accountDAO.AddAcount(login, password);
        }

        public bool CanCreateAccount(string newLogin, string newPassword)
        {
            foreach(Account account in _accountDAO.GetAllAccounts())
            {
                if (account.Login.Equals(newLogin))
                {
                    return false;
                }
            }
            if(newLogin.Length < 3 || newPassword.Length < 3)
            {
                return false;
            }
            //TODO: Validation Password
            return true;
        }

        public bool CanLogin(string login, string password)
        {
            if(_accountDAO.GetAccountByLogin(login) == null)
            {
                return false;
            }
            return _accountDAO.GetAccountByLogin(login).Password.Equals(password);
        }

        public string[] GetAccountRoles(string login)
        {
            return _accountDAO.GetAccountRoles(login);
        }

        public string[] GetRoles()
        {
            return _accountDAO.GetRoles();
        }
    }
}
