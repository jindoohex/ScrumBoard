using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.model
{
    public enum UserRole {Guest, Member, Admin}
    public class User
    {
        #region Instance Fields

        private string _userName;
        private string _passWord;

        private UserRole _specifiedUserRole;

        #endregion

        #region Constructors

        public User() // DEFAULT CONSTRUCTOR
        {
            
        }

        public User(string userName, string passWord, UserRole specifiedUserRole)
        {
            _userName = userName;
            _passWord = passWord;
            _specifiedUserRole = specifiedUserRole;
        }

        #endregion


        #region Properties

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string PassWord
        {
            get => _passWord;
            set => _passWord = value;
        }

        public UserRole SpecifiedUserRole
        {
            get => _specifiedUserRole;
            set => _specifiedUserRole = value;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"{nameof(UserName)}: {UserName}, {nameof(PassWord)}: {PassWord}, {nameof(SpecifiedUserRole)}: {SpecifiedUserRole}";
        }

        #endregion

    }
}
