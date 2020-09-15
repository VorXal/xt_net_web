using Common;
using JsonTaskDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IAwardDAO _awardDAO;
        private static readonly IAwardBLL _awardLogic;

        public static IAwardDAO AwardDAO => _awardDAO;
        public static IAwardBLL AwardLogic => _awardLogic;

        private static readonly IUserDAO _userDAO;
        private static readonly IUserBLL _userLogic;

        public static IUserDAO UserDAO => _userDAO;
        public static IUserBLL UserLogic => _userLogic;
        static DependencyResolver()
        {
            _awardDAO = new JsonAwardDAO();
            _userDAO = new JsonUserDAO();

            _userLogic = new UserManager(_userDAO, _awardDAO);
            _awardLogic = new AwardManager(_awardDAO, _userDAO);
        }
    }
}
