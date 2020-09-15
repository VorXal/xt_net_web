using Common;
using Entities;
using JsonTaskDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class UserManager : IUserBLL
    {
        private readonly IUserDAO _userDAO;
        private readonly IAwardDAO _awardDAO;

        public UserManager(IUserDAO userDAO, IAwardDAO awardDAO)
        {
            _userDAO = userDAO;
            _awardDAO = awardDAO;
        }

        public void AddAward(string id, string awardId)
        {
            _userDAO.AddAward(id, awardId);
        }

        public void AddUser(string name, DateTime dob, int age)
        {
            _userDAO.AddUser(new User(name, dob, age));
        }

        public List<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public List<Award> GetAwards(string _id)
        {
            List<string> ids = GetUserByID(_id).Awards;
            List<Award> awards = new List<Award>();
            foreach (string id in ids)
            {
                awards.Add(_awardDAO.GetAwardByID(id));
            }

            return awards;
        }

        public User GetUserByID(string id)
        {
            return _userDAO.GetUserByID(id);
        }

        public void RemoveUserByID(string id)
        {
            if(_userDAO.GetUserByID(id).Awards.Count != 0)
            {
                List<Award> awards = _awardDAO.GetAllAwards();
                foreach(Award a in awards)
                {
                    a.Users.Remove(a.Users.FirstOrDefault(n => n == id));
                }
                _awardDAO.UpdateDatabase(awards);
            }
            _userDAO.RemoveUserByID(id);
        }
    }
}
