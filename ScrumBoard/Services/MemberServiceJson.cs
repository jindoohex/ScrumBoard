using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ScrumBoard.MockData;
using ScrumBoard.util;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class MemberServiceJson : IMemberService
    {
        private static int nextId = 1;

        private string JsonFile = @"Data/TeamMember.json";

        private List<TeamMember> _teamMembers;

        public List<TeamMember> GetAllTeamMEmbers()
        {
            return _teamMembers;
        }

        public MemberServiceJson()
        {
            _teamMembers = JsonFileReader.ReadJsonGeneric<TeamMember>((JsonFile));
            if (_teamMembers.Count == 0)
            {
                _teamMembers = MockTeamMembers.GetAllTeamMembers();
            }
            
            nextId = _teamMembers.Max(tm => tm.Id) + 1;
            
        }

        public List<TeamMember> GetAllTeamMembers()
        {
            return _teamMembers;
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

            JsonFileWriter.WriteToJsonGeneric(_teamMembers, JsonFile);
            return newTeamMember;
        }

        public TeamMember Remove(int id)
        {
            TeamMember teamMemberToBeDeleted = null;
            foreach (TeamMember tm in _teamMembers)
            {
                if (tm.Id == id)
                {
                    teamMemberToBeDeleted = tm;
                    break;
                }
            }
            if (teamMemberToBeDeleted != null)
            {
                _teamMembers.Remove(teamMemberToBeDeleted);
            }
            JsonFileWriter.WriteToJsonGeneric(_teamMembers, JsonFile);
            return teamMemberToBeDeleted;
        }

        public TeamMember Modify(TeamMember modifiedTeamMember)
        {
            TeamMember tm = GetById(modifiedTeamMember.Id);

            tm.Id = modifiedTeamMember.Id;
            tm.Name = modifiedTeamMember.Name;
            tm.Email = modifiedTeamMember.Email;
            tm.SpecifiedTeamMemberRole = modifiedTeamMember.SpecifiedTeamMemberRole;

            JsonFileWriter.WriteToJsonGeneric(_teamMembers, JsonFile);
            return tm;
        }
    }
}
