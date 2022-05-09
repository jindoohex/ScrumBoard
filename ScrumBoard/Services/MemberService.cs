using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoard.MockData;
using ScrumBoardLib.model;
using ScrumBoard.Services;
using ScrumBoard.util;

namespace ScrumBoard.Services
{
    public class MemberService /*: IMemberService*/
    {
        private List<TeamMember> _teamMembers;

        public int nextId { get; private set; }

        public List<TeamMember> GetAllTeamMembers()
        {
            return _teamMembers;
        }

        public MemberService()
        {
            //_teamMembers =
            _teamMembers = MockTeamMembers.GetAllTeamMembers();
        }
        public TeamMember GetById(int id)
        {
            foreach (TeamMember tm in _teamMembers)
            {
                if (tm.Id == id)
                {
                    return tm;
                }
            }

            return null;
        }

        public List<TeamMember> GetByTeamMemberRole(TeamMember.TeamMemberRole teamMemberRole)
        {
            List<TeamMember> memberListByRole = new List<TeamMember>();

            foreach (TeamMember tm in _teamMembers)
            {
                if (tm.SpecifiedTeamMemberRole == teamMemberRole)
                {
                    memberListByRole.Add(tm);
                }
            }

            if (memberListByRole.Count == 0)
            {
                throw new ArgumentNullException();
            }

            return memberListByRole;
        }

        public TeamMember Create(TeamMember newTeamMember)
        {
            newTeamMember.Id = nextId++;
            _teamMembers.Add(newTeamMember);

            return newTeamMember;
        }

        public TeamMember Remove(int id)
        {
            TeamMember teamMembersToBeDeleted = null;
            foreach (TeamMember tm in _teamMembers)
            {
                if (tm.Id == id)
                {
                    teamMembersToBeDeleted = tm;
                    break;
                }
            }
            if (teamMembersToBeDeleted != null)
            {
                _teamMembers.Remove(teamMembersToBeDeleted);
            }
            return teamMembersToBeDeleted;
        }

        public TeamMember Modify(TeamMember modifiedTeamMember)
        {
            TeamMember tm = GetById(modifiedTeamMember.Id);

            tm.Id = modifiedTeamMember.Id;
            tm.Name = modifiedTeamMember.Name;
            tm.Email = modifiedTeamMember.Email;
            tm.SpecifiedTeamMemberRole = modifiedTeamMember.SpecifiedTeamMemberRole;

            return tm;
        }
    }
}
