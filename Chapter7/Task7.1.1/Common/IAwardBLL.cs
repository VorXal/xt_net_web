using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAwardBLL
    {
        List<Award> GetAllAwards();
        Award GetAwardByID(string id);
        void AddAward(string title);
        void AddUser(string id, string userId);
        void RemoveAwardByID(string id);
        List<User> GetUsers(string id);
    }
}
