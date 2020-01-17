using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>
    /// Represents a task within a project.
    /// A project may have more than one task.
    /// </summary>
    /// <remarks>   All properties are public. </remarks>
    [Serializable]
    public class Task
    {
        private Guid taskId;
        private string name;
        private Status status;

        /// <summary>   Gets or sets the id. </summary>
        ///
        /// <value> The identifier of the task. </value>

        public Guid TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name of the task. </value>

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        public Status TheStatus
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>   Gets the name and status. </summary>
        ///
        /// <value> The name and status formatted as one string. </value>

        public string NameAndStatus
        {
            get { return name + " - " + status;  }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Task() { }

        /// <summary>   The only Constructor. </summary>
        ///
        /// <remarks>   Sets the basic properties of the task. </remarks>
        ///
        /// <param name="id">       The identifier. </param>
        /// <param name="name">     The name of the task. </param>
        /// <param name="status">   The status. </param>

        public Task(Guid id, string name, Status status)
        {
            this.taskId = id;
            this.name = name;
            this.status = status;
        }
    }
}
