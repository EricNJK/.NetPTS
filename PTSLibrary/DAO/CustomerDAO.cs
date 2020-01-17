using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    /// <summary>   A customer database access object. </summary>
    ///
    /// <remarks>   Provides an interface through which a customer can access the database. </remarks>

    class CustomerDAO : SuperDAO
    {
        /// <summary>   Authenticates a customer. </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="username"> The username. </param>
        /// <param name="password"> The customer password. </param>
        ///
        /// <returns>   The customer id but when authentication fails, returns '0'. </returns>

        public int Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            sql = "SELECT CustomerId FROM Customer WHERE Username = @usr AND Password= @pass";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@usr", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            int id = 0;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["CustomerId"];
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
            return id;
        }

        /// <summary>   Gets list of projects. </summary>
        ///
        /// <remarks>   This method queries the database for projects that belong to a customer. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="customerId">   Identifier for the customer. </param>
        ///
        /// <returns>   The list of projects. </returns>

        public List<Project> GetListOfProjects(int customerId)
        {   
            
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Project> projects;
            projects = new List<Project>();

            sql = "SELECT * FROM Project WHERE CustomerId = @cust";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@cust", SqlDbType.Int).Value = customerId;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                SqlConnection cn2; SqlCommand cmd2; SqlDataReader dr2;// string sql2;    //custom
                while (dr.Read())
                {
                    List<Task> tasks = new List<Task>();
                    sql = "SELECT * FROM Task WHERE ProjectId = @pid";
                    cn2 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    cmd2 = new SqlCommand(sql, cn2);
                    cmd2.Parameters.Add("@pid", SqlDbType.UniqueIdentifier).Value = (Guid)dr["ProjectId"];
                    cn2.Open();
                    dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Task t = new Task((Guid)dr2["TaskId"], dr2["Name"].ToString(),
                                                (Status)dr2["StatusId"]);
                        tasks.Add(t);
                    }
                    dr2.Close();
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"],
                                        (DateTime)dr["ExpectedEndDate"], (Guid)dr["ProjectId"], tasks);
                    projects.Add(p);
                    cn2.Close();
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
