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
    public class AddMemberModel : PageModel
    {
        // SERVICE
        #region Instance Fields
        private readonly IMemberService _teamMemberService;
        #endregion

        // PROPERTIES
        #region Properties
        [BindProperty]
        public TeamMember TeamMember { get; set; }
        #endregion

        public AddMemberModel(IMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        // METHODS
        #region Methods
        public void OnGet()
        {
            TeamMember = new TeamMember();
        }

        public IActionResult OnPost()
        {
            TeamMember createTeamMember = _teamMemberService.Create(TeamMember);
            return RedirectToPage("Index");
        }
        #endregion
    }
}
