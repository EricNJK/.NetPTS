using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   A project. </summary>
    ///
    /// <remarks>   Represents a project that has been commissioned with the company. 
    ///             Note that there is no default constructor.</remarks>
    [Serializable]
    public class Project
    {
        private string name;
        private DateTime expectedStartDate;
        private DateTime expectedEndDate;
        private Customer theCustomer;
        private Guid projectId;
        private List<Task> tasks;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Project() { }

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="name">         The project name. </param>
        /// <param name="startDate">    The expected start date. </param>
        /// <param name="endDate">      The expected end date. </param>
        /// <param name="projectId">    The identifier of the project. </param>
        /// <param name="customer">     The customer to who the project belongs. </param>

        public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, Customer customer)
        {
            this.name = name;
            this.expectedStartDate = startDate;
            this.expectedEndDate = endDate;
            this.projectId = projectId;
            this.theCustomer = customer;
        }

        /// <summary>   Second Constructor. </summary>
        ///
        /// <remarks>   Has an extra parameter <see cref="tasks"/> </remarks>
        ///
        /// <param name="name">         The project name. </param>
        /// <param name="startDate">    The expected start date. </param>
        /// <param name="endDate">      The expected end date. </param>
        /// <param name="projectId">    The identifier of the project. </param>
        /// <param name="tasks">        The list of tasks within the project. </param>

        public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, List<Task> tasks)
        {
            this.name = name;
            this.expectedStartDate = startDate;
            this.expectedEndDate = endDate;
            this.projectId = projectId;
            this.tasks = tasks;
        }

        /// <summary>   Gets or sets the name of the project. </summary>
        ///
        /// <value> The name. </value>

        public string Name { get => name; set => name = value; }

        /// <summary>   Gets or sets the expected start date. </summary>
        ///
        /// <value> The expected start date. </value>

        public DateTime ExpectedStartDate { get => expectedStartDate; set => expectedStartDate = value; }

        /// <summary>   Gets or sets the expected end date. </summary>
        ///
        /// <value> The expected end date. </value>

        public DateTime ExpectedEndDate { get => expectedEndDate; set => expectedEndDate = value; }

        /// <summary>   Gets the identifier of the project. </summary>
        ///
        /// <value> The identifier of the project. </value>
        /// 
        /// <remarks> The projectId cannot be changed. </remarks>

        public Guid ProjectId { get => projectId; }

        /// <summary>   Gets or sets the Customer. </summary>
        ///
        /// <value> The customer who commissioned the project. </value>

        public Customer TheCustomer { get => theCustomer; set => theCustomer = value; }

        /// <summary>   Gets or sets the tasks. </summary>
        ///
        /// <value> The list of tasks within the project. </value>

        public List<Task> Tasks { get => tasks; set => tasks = value; }
    }
}
