using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User(string name, DateTime dob, int age)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            DoB = dob;
            Age = age;
            Awards = new List<string>();
        }

        [JsonConstructor]
        public User(Guid id, string name, DateTime dob, int age, List<string> awards)
        {
            ID = id.ToString();
            Name = name;
            DoB = dob;
            Age = age;
            Awards = awards;
        }

        public string ID { get; private set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public int Age { get; set; }
        public List<string> Awards { get; private set; }
    }
}
