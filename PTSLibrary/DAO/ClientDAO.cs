﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PTSLibrary.DAO
{
    /// <summary>   A client database access object. </summary>
    ///
    /// <remarks>   A client refers to a team leader (Not a Customer). This DAO allows a team leader to manage projects assigned to their team. </remarks>

    class ClientDAO : SuperDAO
    {
        /// <summary>   Authenticates the team leader. </summary>
        ///
        /// <remarks>   This method authenticates users only if they are team leaders. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="username"> The username. </param>
        /// <param name="password"> The password. </param>
        ///
        /// <returns>   A TeamLeader. </returns>

        public TeamLeader Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            TeamLeader teamLeader = null;
            sql = "SELECT DISTINCT Person.Name, UserId, TeamId FROM Person INNER JOIN Team ON (Team.TeamLeaderId = Person.UserId) " +
                "WHERE  Username= @usr AND Password= @pass";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@usr", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    teamLeader = new TeamLeader(dr["Name"].ToString(), (int)dr["UserId"], (int)dr["TeamId"]);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                cn.Close();
            }
            return teamLeader;
        }

        /// <summary>   Gets list of projects. </summary>
        ///
        /// <remarks>   Gets the list of projects for a particular team. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="teamId">   Identifier for the team. </param>
        ///
        /// <returns>   The list of projects. </returns>

        public List<Project> GetListOfProjects(int teamId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Project> projects;
            projects = new List<Project>();
            sql = "SELECT DISTINCT P.* FROM Project AS P INNER JOIN Task AS T ON (P.ProjectId = T.ProjectId) WHERE T.TeamId = @team";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@team", SqlDbType.Int).Value = teamId;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer cust = GetCustomer((int)dr["CustomerId"]);
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"],
                   (DateTime)dr["ExpectedEndDate"], (Guid)dr["ProjectId"], cust);
                    projects.Add(p);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list", ex);
            }
            finally
            {
                cn.Close();
            }
            return projects;
        }
    }
}
