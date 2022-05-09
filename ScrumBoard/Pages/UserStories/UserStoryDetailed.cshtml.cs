using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoardLib;
using ScrumBoard.Pages;
using ScrumBoard.MockData;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class UserStoryDetailedModel : PageModel
    {
        #region Instance Fields
        private IUSerStoryService _userStoryService;
        #endregion

        #region Properties
        public UserStory UserStory { get; set; }
        #endregion

        #region Constructors
        public UserStoryDetailedModel(IUSerStoryService userStoryService)
        {
            this._userStoryService = userStoryService;
        }
        #endregion

        #region Methods
        public void OnGet(int id)
        {
            UserStory = _userStoryService.GetById(id);
        }
        #endregion
    }
}
