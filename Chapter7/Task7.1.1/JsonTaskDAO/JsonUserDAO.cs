using Common;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTaskDAO
{
    public class JsonUserDAO : IUserDAO
    {
        private string pathToFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Users.JSON");
        public void AddAward(string id, string awardId)
        {
            List<User> temp = GetAllUsers();
            temp.FirstOrDefault(n => n.ID.Equals(id)).Awards.Add(awardId);
            List<Award> awards = new JsonAwardDAO().GetAllAwards();
            awards.FirstOrDefault(n => n.ID.Equals(awardId)).Users.Add(id);

            UpdateDatabase(temp);
            new JsonAwardDAO().UpdateDatabase(awards);
        }

        public void AddUser(User user)
        {
            List<User> temp = GetAllUsers();
            temp.Add(user);

            UpdateDatabase(temp);
        }

        public List<User> GetAllUsers()
        {
            string json = File.ReadAllText(pathToFile);
            var format = "dd/MM/yyyy";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            List<User> output = JsonConvert.DeserializeObject<List<User>>(json, dateTimeConverter);

            return output;
        }

        public User GetUserByID(string id)
        {
            List<User> all = GetAllUsers();
            return all.FirstOrDefault(n => n.ID.Equals(id));
        }

        public void RemoveUserByID(string id)
        {
            List<User> temp = GetAllUsers();
            User forDelete = GetUserByID(id);
            temp.Remove(temp.FirstOrDefault(n => n.ID.Equals(id)));

            UpdateDatabase(temp);
        }

        public void UpdateDatabase(List<User> temp)
        {
            var jsonToOutput = JsonConvert.SerializeObject(temp, Formatting.Indented);

            File.WriteAllText(pathToFile, jsonToOutput);
        }
    }
}
