using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IUserDAO
    {
        List<User> GetAllUsers();
        User GetUserByID(string id);
        void AddUser(User user);
        void RemoveUserByID(string id);
        void AddAward(string id, string awardId);
        void UpdateDatabase(List<User> awards);
        void EditUser(string id, string name, DateTime dob, int age);
    }
}
