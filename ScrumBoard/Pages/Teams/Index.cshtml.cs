using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private List<TeamMember> _teamMembers = new List<TeamMember>(); // Creates the list directly
        private IMemberService _teamMemberService;
        private static List<TeamMember> _originalMemberList;

        public List<TeamMember> TeamMembers => _teamMembers;

        public IndexModel(IMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        public void OnGet()
        {
            _originalMemberList = _teamMemberService.GetAllTeamMembers();
            _teamMembers = new List<TeamMember>(_originalMemberList);
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
