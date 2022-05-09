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
    public class RemoveMemberModel : PageModel
    {
        // SERVICE
        #region Instance Fields
        private IMemberService _teamMemberService;
        #endregion

        // PROPERTIES
        #region Properties
        [BindProperty]
        public TeamMember TeamMember { get; set; }
        #endregion


        #region Constructors
        public RemoveMemberModel(IMemberService teamMemberService)
        {
            this._teamMemberService = teamMemberService;
        }
        #endregion

        // METHODS
        #region Methods
        public void OnGet(int id)
        {
            TeamMember = _teamMemberService.GetById(id);
        }

        public IActionResult OnoPost(int id)
        {
            TeamMember teamMemberToBeDeleted = _teamMemberService.Remove(id);
            return RedirectToPage("Index");
        }
        #endregion
    }
}
