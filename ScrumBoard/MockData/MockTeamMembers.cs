using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.MockData
{
    public class MockTeamMembers
    {

        public static readonly List<TeamMember> teamMembers = new List<TeamMember>()
        {
            new TeamMember(1, "Alex", "dummymail@hotmail.com", TeamMember.TeamMemberRole.ProductOwner),
            new TeamMember(2, "Jensen", "dummydummymail@hotmail.com", TeamMember.TeamMemberRole.ScrumMaster),
            new TeamMember(3, "Griebel", "dumdummymail@hotmail.com", TeamMember.TeamMemberRole.Member)
        };

        public static List<TeamMember> GetAllTeamMembers()
        {
            return teamMembers;
        }
    }
}
