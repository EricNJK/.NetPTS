using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   The super facade. </summary>
    ///
    /// <remarks>   Provides a public interface to the business component. </remarks>

    public class PTSSuperFacade : MarshalByRefObject
    {

        /// <summary>   The SuperDAO used for data access. </summary>
        protected DAO.SuperDAO dao;

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Creates a SuperFacade that can be used by all users. </remarks>
        ///
        /// <param name="dao">  The DAO to be used. </param>

        public PTSSuperFacade(DAO.SuperDAO dao)
        {
            this.dao = dao;
        }

        /// <summary>   Gets list of tasks. </summary>
        ///
        /// <remarks>   Method to retrieve tasks for a specific project. </remarks>
        ///
        /// <param name="projectId">    Identifier for the project. </param>
        ///
        /// <returns>   An array of tasks. </returns>

        public Task[] GetListOfTasks(Guid projectId)
        {
            return (dao.GetListOfTasks(projectId)).ToArray();
        }
    }
}
