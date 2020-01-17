using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    /// <summary>   The super DAO. </summary>
    ///
    /// <remarks>   Acts as a base class for data access objects. 
    ///             DAO's provide an interface through which applications access the database indirectly. </remarks>

    public class SuperDAO
    {
        /// <summary>   Gets the customer. </summary>
        ///
        /// <remarks>   This method queries the database for customer details using a given Customer (User) Id. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs during sql query. </exception>
        ///
        /// <param name="custId">   Identifier for the customer. </param>
        ///
        /// <returns>   The customer. </returns>

        protected Customer GetCustomer(int custId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            Customer cust;

            sql = "SELECT * FROM Customer WHERE CustomerId = " + custId;
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                dr.Read();
                cust = new Customer(dr["Name"].ToString(), (int)dr["CustomerId"]);
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting Customer", ex);
            }
            finally
            {
                cn.Close();
            }
            return cust;
        }

        /// <summary>   Gets list of tasks for a given project. </summary>
        ///
        /// <remarks>   Gets the tasks saved in the database for one project. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an sql exception error condition occurs. </exception>
        ///
        /// <param name="projectId">    Identifier for the project. </param>
        ///
        /// <returns>   The list of tasks. </returns>

        public List<Task> GetListOfTasks(Guid projectId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Task> tasks;
            tasks = new List<Task>();

            sql = "SELECT * FROM Task WHERE ProjectId = '" + projectId + "'";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Task t = new Task((Guid)dr["TaskId"], dr["Name"].ToString(), (Status)((int)dr["StatusId"]));
                    tasks.Add(t);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error getting tasks list", ex);
            }
            finally
            {
                cn.Close();
            }
            return tasks;
        }
    }
}
