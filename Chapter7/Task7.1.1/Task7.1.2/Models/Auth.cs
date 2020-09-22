using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task7._1._2.Models
{
    public static class Auth
    {
        public static bool CanLogin(string login, string password) => DependencyResolver.DependencyResolver.AccountLogic.CanLogin(login, password);
    }
}