using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Template;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class MemberServiceDB : IMemberService
    {

        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserStoryDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Assisting 'method' for >> reading the UserStories << from the database
        private TeamMember ReadTeamMember(SqlDataReader reader)
        {
            TeamMember tm = new TeamMember();

            tm.Id = reader.GetInt32(0);
            tm.Name = reader.GetString(1);
            tm.Email = reader.GetString(2);
            tm.SpecifiedTeamMemberRole = Enum.Parse<TeamMember.TeamMemberRole>(reader.GetString(3));

            // Alternative method for the enumeration (REQUIRES CHANGES IN THE DATABASE: NVARCHAR => INT)
            // us.SpecificUserStoryStatus = reader.GetInt32(5)

            return tm;
        }


        // For 'select' of all TeamMembers
        public List<TeamMember> GetAllTeamMembers()
        {
            List<TeamMember> teamMemberList = new List<TeamMember>();
            string sql = "Select * from TeamMember";

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
                    TeamMember tm = ReadTeamMember(reader);
                    teamMemberList.Add(tm);
                }
            }
            return teamMemberList;
        }

        // For 'selecting' TeamMember by specific role
        public List<TeamMember> GetByTeamMemberRole(TeamMember.TeamMemberRole teamMemberRole)
        {
            string sql = "Select * from TeamMember where TeamMemberRole=@TeamMemberRole";

            List<TeamMember> teamMemberByRoleList = new List<TeamMember>();

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@TeamMemberRole", teamMemberRole);

                // Always with 'select'
                SqlDataReader reader = cmd.ExecuteReader();

                // Reads all rows
                while (reader.Read())
                {
                    TeamMember tm = ReadTeamMember(reader);
                    teamMemberByRoleList.Add(tm);
                }
            }
            // Let this return null OR make it throw a new KeyNotFoundException();
            return teamMemberByRoleList;
        }
        

        // For 'select by ID'
        public TeamMember GetById(int id)
        {
            string sql = "Select * from TeamMember where ID=@ID";

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
                    TeamMember tm = ReadTeamMember(reader);
                    return tm;
                }
            }
            // Let this return null OR make it throw a new KeyNotFoundException();
            return null;
        }



        // For 'inserting' into the database
        public TeamMember Create(TeamMember newTeamMember)
        {
            string sql = "Insert into TeamMember values(@Name, @Email, @TeamMemberRole)";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@Name", newTeamMember.Name);
                cmd.Parameters.AddWithValue("@Email", newTeamMember.Email);
                cmd.Parameters.AddWithValue("@TeamMemberRole", newTeamMember.SpecifiedTeamMemberRole);

                // Always with 'Insert', 'Delete', 'Update functionality
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Error
                    throw new ArgumentException(@"The TeamMember is not within our listing parameters.");
                }

                return newTeamMember;
            }

        }

        public TeamMember Remove(int id)
        {
            TeamMember deletedTeamMember = GetById(id);

            string sql = "Delete from TeamMember where ID=@ID";

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
                    throw new ArgumentException("@The TeamMember is not within our listings.");
                }
            }

            return deletedTeamMember;
        }

        public TeamMember Modify(TeamMember modifiedTeamMember)
        {

            string sql = "Update TeamMember set Id=@ID, Name=@Name, Email=@Email, TeamMemberRole=@TeamMemberRole where ID=@ID";

            // Establish connection 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@ID", modifiedTeamMember.Id);
                cmd.Parameters.AddWithValue("@Name", modifiedTeamMember.Name);
                cmd.Parameters.AddWithValue("@Email", modifiedTeamMember.Email);
                cmd.Parameters.AddWithValue("@TeamMemberRole", modifiedTeamMember.SpecifiedTeamMemberRole);

                // Always with 'Insert', 'Delete', 'Update'
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Error
                    throw new ArgumentException(@"UserStory is not within listings.");
                }

                return modifiedTeamMember;
            }

        }
    }
}
