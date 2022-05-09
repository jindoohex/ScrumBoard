using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ScrumBoard.Model;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class UserStoryServiceDB : IUSerStoryService

    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserStoryDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Assisting 'method' for >> reading the UserStories << from the database
        private UserStory ReadUserStory(SqlDataReader reader)
        {
            UserStory us = new UserStory();

            us.ID = reader.GetInt32(0);
            us.Title = reader.GetString(1);
            us.Description = reader.GetString(2);
            us.StoryPoints = reader.GetInt32(3);
            us.BusinessValue = reader.GetInt32(4);
            us.SpecificUserStoryStatus = Enum.Parse<UserStoryStatus>(reader.GetString(5));

            // Alternative method for the enumeration (REQUIRES CHANGES IN THE DATABASE: NVARCHAR => INT)
            // us.SpecificUserStoryStatus = reader.GetInt32(5)
            
            return us;
        }


        // For 'select'
        public List<UserStory> GetAll()
        {
            List<UserStory> userStoryList = new List<UserStory>();
            string sql = "Select * from UserStory";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Always for 'select' queries
                SqlDataReader reader = cmd.ExecuteReader();

                // Read all rows
                while (reader.Read())
                {
                    UserStory us = ReadUserStory(reader);
                    userStoryList.Add(us);
                }
            }
            return userStoryList;
        }


        public UserStory GetById(int id)
        {
            string sql = "Select * from UserStory where ID=@ID";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@ID", id);

                // Always with 'select'
                SqlDataReader reader = cmd.ExecuteReader();

                // Reads all rows
                while (reader.Read())
                {
                    UserStory us = ReadUserStory(reader);
                    return us;
                }
            }
            // Let this return null OR make it throw a new KeyNotFoundException();
            return null;
        }


        public UserStory Create(UserStory newUserStory)
        {
            string sql = "Insert into UserStory values(@Title, @Description, @StoryPoints, @BusinessValue, @SpecificUserStoryStatus)";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@Title", newUserStory.Title);
                cmd.Parameters.AddWithValue("@Description", newUserStory.Description);
                cmd.Parameters.AddWithValue("@StoryPoints", newUserStory.StoryPoints);
                cmd.Parameters.AddWithValue("@BusinessValue", newUserStory.BusinessValue);
                cmd.Parameters.AddWithValue("@SpecificUserStoryStatus", newUserStory.SpecificUserStoryStatus);
                cmd.Parameters.AddWithValue("@AssociatedTeamMember", newUserStory.AssociatedTeamMembers);

                // Always with 'Insert', 'Delete', 'Update functionality
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Error
                    throw new ArgumentException(@"The UserStory is not within our listing parameters.");
                }

                return newUserStory;
            }
            
        }


        public UserStory Delete(int id)
        {
            UserStory deletedUserStory = GetById(id);

            string sql = "Delete from UserStory where ID=@ID";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@ID", id);

                // Always with 'Insert', 'Delete', 'Update functionality
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Error
                    throw new ArgumentException("@The UserStory is not within our listings.");
                }
            }

            return deletedUserStory;
        }


        public UserStory Modify(UserStory modifiedUserStory, TeamMember associatedTeamMember)
        {

            string sql = "Update UserStory set Title=@Title, Description=@Description, StoryPoints=@StoryPoints, BusinessValue=@BusinessValue, SpecificUserStoryStatus=@SpecificUserStoryStatus, AssociatedTeamMember=@AssociatedTeamMember where ID=@ID";

            // Establish connection 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@ID", modifiedUserStory.ID);
                cmd.Parameters.AddWithValue("@Title", modifiedUserStory.Title);
                cmd.Parameters.AddWithValue("@Description", modifiedUserStory.Description);
                cmd.Parameters.AddWithValue("@StoryPoints", modifiedUserStory.StoryPoints);
                cmd.Parameters.AddWithValue("@BusinessValue", modifiedUserStory.BusinessValue);
                cmd.Parameters.AddWithValue("@SpecificUserStoryStatus", modifiedUserStory.SpecificUserStoryStatus);
                cmd.Parameters.AddWithValue("@AssociatedTeamMember", associatedTeamMember.Id);


                // Always with 'Insert', 'Delete', 'Update'
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Error
                    throw new ArgumentException(@"UserStory is not within listings.");
                }

                return modifiedUserStory;
            }

        }
    }
}
