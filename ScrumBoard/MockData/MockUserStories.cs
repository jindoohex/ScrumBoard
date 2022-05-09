using ScrumBoardLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoard.MockData
{
    public class MockUserStories
    {

        private static readonly List<UserStory> userStories = new List<UserStory>()
        {
        new UserStory("Create Story", "As P.O I want to create a new story so ...", UserStoryStatus.Dummy),
        new UserStory("Edit Story", "As P.O I want to edit a story so ...", UserStoryStatus.Dummy),
        new UserStory("Move Story", "As team member I want to move a story so ...", UserStoryStatus.Dummy),
        new UserStory("Delete Story", "As team member I want to delete a story so ...", UserStoryStatus.Dummy)
        };

        public static List<UserStory> GetUserStories()
        {
            return userStories;
        }
    }
}
