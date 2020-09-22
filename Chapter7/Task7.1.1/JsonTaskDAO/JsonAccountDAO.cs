using Common;
using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Configuration;

namespace JsonTaskDAO
{
    public class JsonAccountDAO : IAccountDAO
    {
        private static readonly string pathToFile = WebConfigurationManager.AppSettings.Get("pathToAccountJSON");

        public void AddAcount(string login, string password)
        {
            List<Account> temp = GetAllAccounts();
            temp.Add(new Account(login, password));
            UpdateDatabase(temp);
        }

        public Account GetAccountByLogin(string login)
        {
            foreach(Account account in GetAllAccounts())
            {
                if (account.Login.Equals(login))
                {
                    return account;
                }
            }
            return null;
        }

        public string[] GetAccountRoles(string login)
        {
            foreach (Account account in GetAllAccounts())
            {
                if (account.Login.Equals(login))
                {
                    return account.Roles;
                }
            }
            return null;
        }

        public string[] GetRoles()
        {
            HashSet<string> temp = new HashSet<string>();
            foreach(Account account in GetAllAccounts())
            {
                foreach(string role in account.Roles)
                {
                    temp.Add(role);
                }
            }
            return temp.ToArray();
        }

        public List<Account> GetAllAccounts()
        {
            string json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<Account>>(json);
        }

        private void UpdateDatabase(List<Account> temp)
        {
            var jsonToOutput = JsonConvert.SerializeObject(temp, Formatting.Indented);

            File.WriteAllText(pathToFile, jsonToOutput);
        }
    }
}
