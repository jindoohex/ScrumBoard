using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.MockData
{
    public class MockUsers
    {

        private static readonly List<User> users = new List<User>()
        {
            new User("Alex", "SecretAlex", UserRole.Admin),
            new User("Jensen", "SecretJensen", UserRole.Member),
            new User("Jack", "SecretJack", UserRole.Guest),
        };

        public static List<User> GetAllUsers()
        {
            return users;
        }
    }
}
