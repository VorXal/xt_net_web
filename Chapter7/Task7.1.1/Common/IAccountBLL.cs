using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAccountBLL
    {
        void AddAcount(string login, string password);
        string[] GetAccountRoles(string login);
        string[] GetRoles();
        bool CanLogin(string login, string password);
        bool CanCreateAccount(string newLogin, string newPassword);
    }
}
