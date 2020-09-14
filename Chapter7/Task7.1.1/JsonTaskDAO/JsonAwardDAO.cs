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
    public class JsonAwardDAO : IAwardDAO
    {
        private string pathToFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Awards.JSON");
        public void AddAward(Award award)
        {
            List<Award> temp = GetAllAwards();
            temp.Add(award);

            UpdateDatabase(temp);
        }

        public void AddUser(string id, string userId)
        {
            List<Award> temp = GetAllAwards();
            temp.FirstOrDefault(n => n.ID.Equals(id)).Users.Add(userId);
            List<User> users = new JsonUserDAO().GetAllUsers();
            users.FirstOrDefault(n => n.ID.Equals(userId)).Awards.Add(id);

            UpdateDatabase(temp);
            new JsonUserDAO().UpdateDatabase(users);
        }

        public List<Award> GetAllAwards()
        {
            string json = File.ReadAllText(pathToFile);
            var format = "dd/MM/yyyy";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            List<Award> output = JsonConvert.DeserializeObject<List<Award>>(json, dateTimeConverter);

            return output;
        }

        public Award GetAwardByID(string id)
        {
            List<Award> all = GetAllAwards();
            return all.FirstOrDefault(n => n.ID.Equals(id));
        }

        public void RemoveAwardByID(string id)
        {
            List<Award> temp = GetAllAwards();
            temp.Remove(temp.FirstOrDefault(n => n.ID.Equals(id)));

            UpdateDatabase(temp);
        }

        public void UpdateDatabase(List<Award> temp)
        {
            var jsonToOutput = JsonConvert.SerializeObject(temp, Formatting.Indented);

            File.WriteAllText(pathToFile, jsonToOutput);
        }
    }
}
