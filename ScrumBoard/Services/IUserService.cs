using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetByString(String username);
        User Create(User newUser);
        User Delete(String username);
        User Modify(User modifiedUser);
    }
}
