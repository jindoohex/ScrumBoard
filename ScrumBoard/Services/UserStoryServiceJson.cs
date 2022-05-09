using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ScrumBoard.util;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class UserStoryServiceJson /*: IUSerStoryService*/
    {
        #region Static Instance Field
        private static int nextId = 1; // Sets the value of nextId to the value of id, and then increments

        private string JsonFile = @"Data/UserStory.json";

        private List<UserStory> _userStories;
        #endregion

        public List<UserStory> GetAll()
        {
            return _userStories;
        }

        public UserStoryServiceJson()
        {
            _userStories = JsonFileReader.ReadJsonGeneric<UserStory>((JsonFile));
            nextId = _userStories.Max(u => u.ID) + 1;
        }

        public UserStory GetById(int id)
        {
            foreach (UserStory us in _userStories)
            {
                if (us.ID == id)
                    return us;
            }
            return null;
        }

        public UserStory Create(UserStory newUserStory)
        {
            newUserStory.ID = nextId++;
            _userStories.Add(newUserStory);

            JsonFileWriter.WriteToJsonGeneric(_userStories, JsonFile);
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
            JsonFileWriter.WriteToJsonGeneric(_userStories, JsonFile);
            return userStoryToBeDeleted;
        }

        public UserStory Modify(UserStory modifiedUserStory)
        {
            UserStory us = GetById(modifiedUserStory.ID);

            us.Title = modifiedUserStory.Title;
            us.Description = modifiedUserStory.Description;
            us.ID = modifiedUserStory.ID;
            us.BusinessValue = modifiedUserStory.BusinessValue;
            us.StoryPoints = modifiedUserStory.StoryPoints;
            us.SpecificUserStoryStatus = modifiedUserStory.SpecificUserStoryStatus;

            JsonFileWriter.WriteToJsonGeneric(_userStories, JsonFile);
            return us;
        }
    }
}
