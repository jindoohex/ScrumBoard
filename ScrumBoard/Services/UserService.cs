using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoard.MockData;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class UserService : IUserService
    {
        private static List<User> _users;

        public UserService()
        {
            _users = MockUsers.GetAllUsers();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetByString(string username)
        {
            throw new NotImplementedException();
        }

        public User Create(User newUser)
        {
            throw new NotImplementedException();
        }

        public User Delete(string username)
        {
            throw new NotImplementedException();
        }

        public User Modify(User modifiedUser)
        {
            throw new NotImplementedException();
        }
    }
}
