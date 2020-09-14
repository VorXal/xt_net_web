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
        public void AddAward(string id, string awardId)
        {
            new JsonUserDAO().AddAward(id, awardId);
        }

        public void AddUser(string name, DateTime dob, int age)
        {
            new JsonUserDAO().AddUser(new User(name, dob, age));
        }

        public List<User> GetAllUsers()
        {
            return new JsonUserDAO().GetAllUsers();
        }

        public List<Award> GetAwards(string _id)
        {
            List<string> ids = GetUserByID(_id).Awards;
            List<Award> awards = new List<Award>();
            foreach (string id in ids)
            {
                awards.Add(new AwardManager().GetAwardByID(id));
            }

            return awards;
        }

        public User GetUserByID(string id)
        {
            return new JsonUserDAO().GetUserByID(id);
        }

        public void RemoveUserByID(string id)
        {
            if(new JsonUserDAO().GetUserByID(id).Awards.Count != 0)
            {
                List<Award> awards = new JsonAwardDAO().GetAllAwards();
                foreach(Award a in awards)
                {
                    a.Users.Remove(a.Users.FirstOrDefault(n => n == id));
                }
                new JsonAwardDAO().UpdateDatabase(awards);
            }
            new JsonUserDAO().RemoveUserByID(id);
        }
    }
}
