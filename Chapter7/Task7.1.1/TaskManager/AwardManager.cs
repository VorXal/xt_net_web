using Common;
using Entities;
using JsonTaskDAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class AwardManager : IAwardBLL
    {
        private readonly IAwardDAO _awardDAO;
        private readonly IUserDAO _userDAO;
        public AwardManager(IAwardDAO awardDAO, IUserDAO userDAO)
        {
            _awardDAO = awardDAO;
            _userDAO = userDAO;
        }

        public void AddAward(string title)
        {
            _awardDAO.AddAward(new Award(title));
        }

        public void AddUser(string id, string userId)
        {
            _awardDAO.AddUser(id, userId);
        }

        public List<Award> GetAllAwards()
        {
            return _awardDAO.GetAllAwards();
        }

        public Award GetAwardByID(string id)
        {
            return _awardDAO.GetAwardByID(id);
        }

        public List<User> GetUsers(string _id)
        {
            List<string> ids = GetAwardByID(_id).Users;
            List<User> users = new List<User>();
            foreach(string id in ids)
            {
                users.Add(_userDAO.GetUserByID(id));
            }
            return users;
        }

        public void RemoveAwardByID(string id)
        {
            if(_awardDAO.GetAwardByID(id).Users.Count != 0)
            {
                List<User> users = _userDAO.GetAllUsers();
                foreach (User user in users)
                {
                    user.Awards.Remove(user.Awards.FirstOrDefault(n => n == id));
                }
                _userDAO.UpdateDatabase(users);
            }
            _awardDAO.RemoveAwardByID(id);
        }
    }
}
