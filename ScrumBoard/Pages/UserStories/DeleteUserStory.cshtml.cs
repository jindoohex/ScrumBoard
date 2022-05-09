using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;
using ScrumBoard;
using ScrumBoard.MockData;

namespace ScrumBoard.Pages.UserStories
{
    public class DeleteUserStoryModel : PageModel
    {
        #region Instance Fields
        private IUSerStoryService _userStoryService;
        #endregion

        #region Properties
        [BindProperty]
        public UserStory UserStory { get; set; }
        #endregion

        #region Constructors
        public DeleteUserStoryModel(IUSerStoryService userStoryService)
        {
            this._userStoryService = userStoryService;
        }
        #endregion

        #region Methods
        public void OnGet(int id)
        {
            UserStory = _userStoryService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            UserStory deletedUserStory = _userStoryService.Delete(id);
            return RedirectToPage("Index");
        }
        #endregion
    }
}
