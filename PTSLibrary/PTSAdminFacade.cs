using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   The administrator facade. </summary>
    ///
    /// <remarks>   Provides an interface for administrators to access and manage project data. </remarks>

    public class PTSAdminFacade : PTSSuperFacade
    {
        /// <summary>   The administrator dao. </summary>
        private new DAO.AdminDAO dao;

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Calls SuperDAO constructor with a new <see cref="DAO.AdminDAO"/>. </remarks>

        public PTSAdminFacade() : base(new DAO.AdminDAO())
        {
            dao = (DAO.AdminDAO)base.dao;
        }

        /// <summary>   Authenticates the administrator. </summary>
        ///
        /// <exception cref="Exception">    Thrown when username or password are empty. </exception>
        ///
        /// <param name="username"> The administartor username. </param>
        /// <param name="password"> The password. </param>
        ///
        /// <returns>   Administrator Id. Returns '0' if auth fails.</returns>

        public int Authenticate(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new Exception("Missing Data");
            }
            return dao.Authenticate(username, password);
        }

        /// <summary>   Creates a new project. </summary>
        ///
        /// <exception cref="Exception">    Thrown when name or dates are missing. </exception>
        /// <see cref="DAO.AdminDAO.CreateProject(string, DateTime, DateTime, int, int)"/>

        public void CreateProject(string name, DateTime startDate, DateTime endDate, int customerId, int administratorId)
        {
            if (name == "" || name == null || startDate == null || endDate == null)
            {
                throw new Exception("Missing Project data.");
            }
            dao.CreateProject(name, startDate, endDate, customerId, administratorId);
        }

        /// <summary>   Creates a new task within a project. </summary>
        ///
        /// <exception cref="Exception">    Thrown when name or dates are missing. </exception>
        /// <see cref="DAO.AdminDAO.CreateTask(string, DateTime, DateTime, int, Guid)"/>

        public void CreateTask(string name, DateTime startDate, DateTime endDate, int teamId, Guid projectId)
        {
            if (name == null || name == "" || startDate == null || endDate == null)
            {
                throw new Exception("Missing Data");
            }
            dao.CreateTask(name, startDate, endDate, teamId, projectId);
        }

        /// <summary>   Gets list of customers. </summary>
        /// <see cref="DAO.AdminDAO.GetListOfCustomers()"/>
        /// <returns>   An array of customer. </returns>

        public Customer[] GetListOfCustomers()
        {
            return dao.GetListOfCustomers().ToArray();
        }

        /// <summary>   Gets list of projects. </summary>
        ///
        /// <param name="adminId">  Identifier for the admin. </param>
        ///
        /// <returns>   An array of projects managed by the administrator. </returns>

        public Project[] GetListOfProjects(int adminId)
        {
            return dao.GetListOfProjects(adminId).ToArray();
        }

        /// <summary>   Gets list of teams. </summary>
        /// <see cref="DAO.AdminDAO.GetListOfTeams()"/>
        /// <returns>   An array of team. </returns>

        public Team[] GetListOfTeams()
        {
            return dao.GetListOfTeams().ToArray();
        }
    }
}
