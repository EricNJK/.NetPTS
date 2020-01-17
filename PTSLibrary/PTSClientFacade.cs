using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   The client facade. </summary>
    ///
    /// <remarks>   Allows a team leader to access project data. </remarks>

    public class PTSClientFacade : PTSSuperFacade
    {

        /// <summary>   The database access object for the Client. </summary>
        private new DAO.ClientDAO dao;

        /// <summary>   Default client facade constructor. </summary>
        ///
        /// <remarks>   Takes no arguments. Calls the <see cref="DAO.SuperDAO"/> constructor with a ClientDAO as the argument. </remarks>
        /// <code>
        /// public PTSClientFacade() : base(new DAO.ClientDAO())
        /// {
        ///     dao = (DAO.ClientDAO)base.dao;
        /// }
        /// </code>

        public PTSClientFacade() : base(new DAO.ClientDAO())
        {
            dao = (DAO.ClientDAO)base.dao;
        }

        /// <summary>   Authenticates the team leader. </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="username"> The username. </param>
        /// <param name="password"> The password. </param>
        ///
        /// <returns>   A TeamLeader. </returns>

        public TeamLeader Authenticate(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new Exception("Missing Data");
            }
            return dao.Authenticate(username, password);
        }

        /// <summary>   Gets list of projects. </summary>
        ///
        /// <remarks>   Gets a list of projects for the team from dao then converts the list to an <see cref="Array"/>. </remarks>
        ///
        /// <param name="teamId">   Identifier for the team. </param>
        ///
        /// <returns>   An array of project. </returns>

        public Project[] GetListOfProjects(int teamId)
        {
            return (dao.GetListOfProjects(teamId).ToArray());
        }
    }
}
