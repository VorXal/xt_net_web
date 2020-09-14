using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IUserPL
    {
        void DisplayUsers();
        void CreateNewUser();
        void RemoveUser();
        void DisplayUserAwards();
        void DisplayMenu();
        void AddAward();
    }
}
