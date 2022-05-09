using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class UpdateUserStoryModel : PageModel
    {
        #region Instance Fields
        private IUSerStoryService _userStoryService;
        private IMemberService _teamMemberService;
        #endregion

        [BindProperty]
        #region Properties
        public UserStory UserStory { get; set; }

        [BindProperty]
        public List<TeamMember> TeamMember { get; set; }

        [BindProperty]
        public List<int> StoryPointValues { get; set; }

        [BindProperty]
        public List<int> BusinessValues { get; set; }

        [BindProperty]
        public TeamMember NoListTeamMember { get; set; }

        #endregion

        #region Constructors
        public UpdateUserStoryModel(IUSerStoryService userStoryService, IMemberService teamMemberService)
        {

            _userStoryService = userStoryService;
            _teamMemberService = teamMemberService;
            

            StoryPointValues = new List<int>
            {
                0, 1, 2, 3, 5, 8, 13, 21, 34
            };

            BusinessValues = new List<int>
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

        }
        #endregion

        #region Methods
        public void OnGet(int id)
        {
            UserStory = _userStoryService.GetById(id);
            TeamMember = _teamMemberService.GetAllTeamMembers();
        }
        public IActionResult OnPost(int id)
        {
            UserStory.ID = id;
            UserStory userStory = _userStoryService.Modify(UserStory, NoListTeamMember);
            UserStory.AssociatedTeamMembers.Add(NoListTeamMember);
            return RedirectToPage("Index");
        }
        #endregion

    }
}
