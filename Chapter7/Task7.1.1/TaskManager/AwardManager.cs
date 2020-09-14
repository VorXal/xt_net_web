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
        public void AddAward(string title)
        {
            new JsonAwardDAO().AddAward(new Award(title));
        }

        public void AddUser(string id, string userId)
        {
            new JsonAwardDAO().AddUser(id, userId);
        }

        public List<Award> GetAllAwards()
        {
            return new JsonAwardDAO().GetAllAwards();
        }

        public Award GetAwardByID(string id)
        {
            return new JsonAwardDAO().GetAwardByID(id);
        }

        public List<User> GetUsers(string _id)
        {
            List<string> ids = GetAwardByID(_id).Users;
            List<User> users = new List<User>();
            foreach(string id in ids)
            {
                users.Add(new UserManager().GetUserByID(id));
            }
            return users;
        }

        public void RemoveAwardByID(string id)
        {
            if(new JsonAwardDAO().GetAwardByID(id).Users.Count != 0)
            {
                List<User> users = new JsonUserDAO().GetAllUsers();
                foreach (User user in users)
                {
                    user.Awards.Remove(user.Awards.FirstOrDefault(n => n == id));
                }
                new JsonUserDAO().UpdateDatabase(users);
            }
            new JsonAwardDAO().RemoveAwardByID(id);
        }
    }
}
