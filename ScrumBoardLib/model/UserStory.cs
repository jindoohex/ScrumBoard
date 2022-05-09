using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.model
{
    public enum UserStoryStatus {ProductBackLog, Todo, Doing, Done, DoneDone, Dummy}

    public class UserStory
    {
        #region Instance Fields
        private int _id;
        private string _title;
        private string _description;
        private int _storyPoints;
        private int _businessValue;

        private List<TeamMember> _associatedTeamMembers = new List<TeamMember>();

        private UserStoryStatus _specificUserStoryStatus;

        #endregion


        #region Constructor
        public UserStory():this("Dummy","DummyDummy", UserStoryStatus.ProductBackLog) // Default constructor
        {

        }

        public UserStory(string title, string description, UserStoryStatus specificUserStoryStatus)
        {
            _id = 0;
            Title = title;
            _description = description;
            _storyPoints = 0;
            _businessValue = 0;
            _specificUserStoryStatus = specificUserStoryStatus;
        }

        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set 
            {
                CheckTitle(value);
                _title = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                CheckDescription(value);
                _description = value;
            }
        }

        public int StoryPoints
        {
            get { return _storyPoints; }
            set 
            {
                CheckStoryPoints(value);
                _storyPoints = value;
            }
        }

        public int BusinessValue
        {
            get { return _businessValue;}
            set 
            {
                CheckBusinessValue(value);
                _businessValue = value;
            }
        }

        //public List<TeamMember> AssociatedTeamMembers => _associatedTeamMembers;

        public List<TeamMember> AssociatedTeamMembers
        {
            get => _associatedTeamMembers;
            set => _associatedTeamMembers = value;
        }

        public UserStoryStatus SpecificUserStoryStatus
        {
            get => _specificUserStoryStatus;
            set => _specificUserStoryStatus = value;
        }

        #endregion

        #region Methods
        private static void CheckTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("The title must have a value.");
            }

            if (title.Length < 3)
            {
                throw new ArgumentException("The 'title' must contain at least three characters.");
            }
        }

        private void CheckDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("The description must have a value.");
            }

            if (description.Length < 10)
            {
                throw new ArgumentException("The description must contain at least ten characters.");
            }
        }

        private void CheckStoryPoints(int sp)
        {
            if (sp < 0)
            {
                throw new ArgumentOutOfRangeException("The added points must be positive");
            }
        }

        private void CheckBusinessValue(int bv)
        {
            if (bv > 10 || bv < 0)
            {
                throw new ArgumentOutOfRangeException("The added points must be between 0 and 10");
            }

        }

        public override string ToString()
        {
            return $"{nameof(ID)}: {ID}, {nameof(Title)}: {Title}, {nameof(Description)}: {Description}, {nameof(StoryPoints)}: {StoryPoints}, {nameof(BusinessValue)}: {BusinessValue}, {nameof(SpecificUserStoryStatus)}: {SpecificUserStoryStatus}";
        }



        #endregion
    }
}