using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAwardPL
    {
        void DisplayAwards();
        void CreateNewAward();
        void RemoveAward();
        void DisplayAwardUsers();
        void DisplayMenu();
        void AddUser();
    }
}
