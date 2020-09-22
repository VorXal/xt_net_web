using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        public string ID { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string[] Roles { get; set; }
        public Account(string login, string password)
        {
            ID = Guid.NewGuid().ToString();
            Login = login;
            Password = password;
            Roles = new string[] {"user"};
        }
        [JsonConstructor]
        public Account(Guid id, string login, string password, string[] roles)
        {
            ID = id.ToString();
            Login = login;
            Password = password;
            Roles = roles;
        }
    }
}
