using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class CreateUserStoryModel : PageModel
    {
        // SERVICE
        #region Instance Fields
        private readonly IUSerStoryService _userStoryService;
        #endregion

        // PROPERTIES
        #region Properties
        [BindProperty]
        public UserStory UserStory { get; set; }
        
        [BindProperty]
        public List<int> StoryPointValues { get; set; }
        
        [BindProperty]
        public List<int> BusinessValues { get; set; }

        public static List<int> StoryPointData()
        {
            List<int> storyPointData = new();
            #region DATA
            storyPointData.Add(0);
            storyPointData.Add(1);
            storyPointData.Add(2);
            storyPointData.Add(3);
            storyPointData.Add(5);
            storyPointData.Add(8);
            storyPointData.Add(13);
            storyPointData.Add(21);
            storyPointData.Add(34);
            #endregion
            return storyPointData;
        }
        public static List<int> BusinessValueData()
        {
            List<int> businessValueData = new();
            #region DATA
            businessValueData.Add(0);
            businessValueData.Add(1);
            businessValueData.Add(2);
            businessValueData.Add(3);
            businessValueData.Add(4);
            businessValueData.Add(5);
            businessValueData.Add(6);
            businessValueData.Add(7);
            businessValueData.Add(8);
            businessValueData.Add(9);
            businessValueData.Add(10);
            #endregion
            return businessValueData;
        }
        #endregion

        // CONSTRUCTORS
        #region Constructors
        public CreateUserStoryModel(IUSerStoryService userStoryService)
        {
            _userStoryService = userStoryService;

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

        // METHODS
        #region Methods
        public void OnGet()
        {
            UserStory = new UserStory();
        }

        public IActionResult OnPost()
        {
            UserStory createUserStory = _userStoryService.Create(UserStory);
            return RedirectToPage("Index");
        }
        #endregion
    }
}
