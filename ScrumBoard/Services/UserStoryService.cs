using ScrumBoardLib.model;
using ScrumBoard.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoard.Services
{
    public class UserStoryService : IUSerStoryService
    {

        private List<UserStory> _userStories;

        public List<UserStory> GetUserStories()
        {
            return _userStories;
        }

        public UserStoryService()
        {
            _userStories = MockUserStories.GetUserStories();
        }

        public UserStory GetUserStory(int id)
        {
            foreach (UserStory userStory in _userStories)
            {
                if (userStory.ID == id)
                    return userStory;
            }
            return null;
        }
        public UserStory DeleteUserStory(int userStoryId)
        {
            UserStory userStoryToBeDeleted = null;
            foreach (UserStory us in _userStories)
            {
                if (us.ID == userStoryId)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }
            if (userStoryToBeDeleted != null)
            {
                _userStories.Remove(userStoryToBeDeleted);
            }
            return userStoryToBeDeleted;
        }


        public List<UserStory> GetAll()
        {
            return _userStories;
        }

        public UserStory GetById(int id)
        {
            foreach (UserStory userStory in _userStories)
            {
                if (userStory.ID == id)
                    return userStory;
            }

            return null;
        }

        public UserStory Create(UserStory newUserStory)
        {
            _userStories.Add(newUserStory);
            return newUserStory;
        }

        public UserStory Delete(int id)
        {
            UserStory userStoryToBeDeleted = null;
            foreach (UserStory us in _userStories)
            {
                if (us.ID == id)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }
            if (userStoryToBeDeleted != null)
            {
                _userStories.Remove(userStoryToBeDeleted);
            }
            return userStoryToBeDeleted;
        }

        public UserStory Modify(UserStory modifiedUserStory, TeamMember associatedTeamMember)
        {
            UserStory us = GetById(modifiedUserStory.ID);

            us.Title = modifiedUserStory.Title;
            us.Description = modifiedUserStory.Description;
            us.ID = modifiedUserStory.ID;
            us.BusinessValue = modifiedUserStory.BusinessValue;
            us.StoryPoints = modifiedUserStory.StoryPoints;
            us.SpecificUserStoryStatus = modifiedUserStory.SpecificUserStoryStatus;

            return us;
        }
    }
}
