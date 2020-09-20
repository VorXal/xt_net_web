using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Award
    {

        public Award(string title)
        {
            ID = Guid.NewGuid().ToString();
            Title = title;
            Users = new List<string>();
        }

        [JsonConstructor]
        public Award(Guid id, string title, List<string> users)
        {
            ID = id.ToString();
            Title = title;
            Users = users;
        }

        public string ID { get; private set; }
        public string Title { get; set; }
        public List<string> Users { get; private set; }
    }
}
