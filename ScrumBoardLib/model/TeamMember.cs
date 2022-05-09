using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.model
{
    public class TeamMember
    {
        #region Instance Fields

        public enum TeamMemberRole {ProductOwner, ScrumMaster, Member}

        private int _id;
        private string _name;
        private string _email;
        private TeamMemberRole _specifiedTeamMemberRole;

        #endregion



        #region Constructors

        public TeamMember()
        {

        }

        public TeamMember(int id, string name, string email, TeamMemberRole specifiedTeamMemberRole)
        {
            _id = id;
            _name = name;
            _email = email;
            _specifiedTeamMemberRole = specifiedTeamMemberRole;
        }

        #endregion

        

        #region Properties

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public TeamMemberRole SpecifiedTeamMemberRole
        {
            get => _specifiedTeamMemberRole;
            set => _specifiedTeamMemberRole = value;
        }

        #endregion



        #region Methods

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(SpecifiedTeamMemberRole)}: {SpecifiedTeamMemberRole}";
        }

        #endregion
    }
}
