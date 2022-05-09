using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    /// <summary>
    /// Interface for the UserStories, with added functionality of CRUD
    /// </summary>
    public interface IUSerStoryService
    {
        /// <summary>
        /// Collects the full list over USerStories
        /// </summary>
        /// <returns>The gathered list of UserStories</returns>
        List<UserStory> GetAll();

        /// <summary>
        /// Collects a UserStory specified by ID
        /// </summary>
        /// <param name="id">Integer value used to collect the specific UserStory</param>
        /// <returns>UserStory by the specific ID</returns>
        UserStory GetById(int id);

        /// <summary>
        /// Creates a new UserStory
        /// </summary>
        /// <param name="newUserStory">Name of the parameter used in the function</param>
        /// <returns>The added UserStory to a list</returns>
        UserStory Create(UserStory newUserStory);

        /// <summary>
        /// Deletes an existing UserStory
        /// </summary>
        /// <param name="id">Integer value needed for removing the specific UserStory</param>
        /// <returns>The updated list without the deleted UserStory</returns>
        UserStory Delete(int id);

        /// <summary>
        /// Modifies a specific UserStory
        /// </summary>
        /// <param name="modifiedUserStory">Name of the parameter used in the function</param>
        /// <returns>The modified UserStory to the list</returns>
        UserStory Modify(UserStory modifiedUserStory, TeamMember associatedTeamMember);
    }
}
