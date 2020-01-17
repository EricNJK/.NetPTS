// file:	User.cs
//
// summary:	Implements the user class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PTSLibrary
{
    /// <summary>   User of the system. </summary>
    ///
    /// <remarks>   Represents any person who interacts with the PTS System.
    ///             This class acts as the base class for <see cref="Customer"/> and <see cref="TeamLeader"/>. </remarks>
    [Serializable]
    public class User
    {

        /// <summary>   The username. </summary>
        protected string name;

        /// <summary>   The user identifier. </summary>
        protected int id;

        /// <summary>   Gets the name. </summary>
        ///
        /// <value> The username. </value>
        /// <remarks> Username is a readonly property. </remarks>

        public string Name
        {
            get { return name; }
        }

        /// <summary>   Gets the identifier. </summary>
        ///
        /// <value> The user identifier. </value>
        /// <remarks> Id is a readonly property. </remarks>

        public int Id
        {
            get { return id; }
        }
    }
}
