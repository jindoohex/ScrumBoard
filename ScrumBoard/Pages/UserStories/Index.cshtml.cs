using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.MockData;
using ScrumBoardLib.model;
using ScrumBoard.Services;
using ScrumBoard.util;

namespace ScrumBoard.Pages.UserStories
{
    public class IndexModel : PageModel
    {
        private List<UserStory> _userStories = new List<UserStory>(); // Creates the list directly
        private IUSerStoryService _userStoryService;
        private static List<UserStory> _originalUserStoryList;
        private IMemberService _memberService;
        private List<TeamMember> _teamMembers;

        public IndexModel(IUSerStoryService userStoryService)
        {
            _userStoryService = userStoryService;
            SortListByValue = new List<string>()
            {
                "Default", "Business Value (HIGHEST FIRST)", "Story Points (HIGHEST FIRST)", "Missing Business Value", "Missing Story Points"
            };
        }

        public List<UserStory> UserStories => _userStories;
        public List<string> SortListByValue { get; private set; }

        [BindProperty]
        public string SortType { get; set; }

        public void OnGet()
        {
            // _userStories = _userStoryService.GetAll();
            _originalUserStoryList = _userStoryService.GetAll();
            _userStories = new List<UserStory>(_originalUserStoryList);
        }

        public IActionResult OnPost()
        {
            DoFind();
            return Page();
        }

        private void DoFind()
        {
            switch (SortType)
            {
                case "Default":
                    _userStories = new List<UserStory>(_originalUserStoryList);
                    break;

                case "Business Value (HIGHEST FIRST)":
                    _userStories = new List<UserStory>(_originalUserStoryList);
                    _userStories.Sort(new SortByBusinessValue());
                    // Below is shown an anonymous comparer similar to IComparer<> but without having to use the interface
                    // UserStories.Sort((us1, us2) =>
                    // {
                    //     return us2.BusinessValue - us1.BusinessValue;
                    // });
                    break;

                case "Story Points (HIGHEST FIRST)":
                    _userStories = new List<UserStory>(_originalUserStoryList);
                    _userStories.Sort(new SortByStoryPoints());
                    break;

                case "Missing Business Value":
                    // LinQ expression 'Where' to identify those without any value of the specified
                    _userStories = _originalUserStoryList.Where(us => us.BusinessValue == 0).ToList();
                    break;

                case "Missing Story Points":
                    // LinQ expression 'Where' to identify those without any value of the specified
                    _userStories = _originalUserStoryList.Where(us => us.StoryPoints == 0).ToList();
                    break;
            }
        }
    }
}
