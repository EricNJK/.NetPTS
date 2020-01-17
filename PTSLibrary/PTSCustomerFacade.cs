using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   The customer facade. </summary>
    ///
    /// <remarks>   Interface used by customers to access data. </remarks>

    public class PTSCustomerFacade : PTSSuperFacade
    {

        /// <summary>   The database access object. </summary>
        private new DAO.CustomerDAO dao;
        
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Takes no arguments .  </remarks>

        public PTSCustomerFacade() : base(new DAO.CustomerDAO())
        {
            dao = (DAO.CustomerDAO)base.dao;
        }

        /// <summary>   Gets list of projects. </summary>
        ///
        /// <remarks>   Gets the projects commissioned by the customer.
        ///             The <see cref="dao"/> returns a list which is converted to an <see cref="Array"/>. </remarks>
        ///
        /// <param name="customerId">   Identifier for the customer. </param>
        ///
        /// <returns>   An array of projects. </returns>

        public Project[] GetListOfProjects(int customerId)
        {
            return (dao.GetListOfProjects(customerId)).ToArray();
        }

        /// <summary> Authenticates the customer. </summary>
        /// 
        /// <param name="name"> Customer's user name: NOT the full name </param>
        /// <param name="password"> Customer's secret password </param>
        /// <returns> The unique customer Id. </returns>
        public int Authenticate(string name, string password)
        {
            return dao.Authenticate(name, password);
        }
    }
}
