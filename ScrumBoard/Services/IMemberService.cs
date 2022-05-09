using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public interface IMemberService
    {
        List<TeamMember> GetAllTeamMembers();
        TeamMember GetById(int id);
        List<TeamMember> GetByTeamMemberRole(TeamMember.TeamMemberRole teamMemberRole);
        TeamMember Create(TeamMember newTeamMember);
        TeamMember Remove(int id);
        TeamMember Modify(TeamMember modifiedTeamMember);
    }
}
