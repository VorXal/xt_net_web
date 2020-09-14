using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IUserBLL
    {
        List<User> GetAllUsers();
        User GetUserByID(string id);
        void AddUser(string name, DateTime dob, int age);
        void AddAward(string id, string award);
        void RemoveUserByID(string id);
        List<Award> GetAwards(string id);
    }
}
