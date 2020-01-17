using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   A team leader. </summary>
    ///
    /// <remarks>   This is a subclass of the <see cref="User"> User superclass. </see> </remarks>
    [Serializable]
    public class TeamLeader : User
    {
        private int teamId;

        /// <summary>   Gets or sets the id of the team. </summary>
        ///
        /// <value> The identifier of the leader's team. </value>

        public int TeamId
        {
            get { return teamId; }
            set { teamId = TeamId; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TeamLeader() { }

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Generates a TeamLeader object with the provided properties. </remarks>
        ///
        /// <param name="name">     The name of the team. </param>
        /// <param name="id">       The user identifier of the team leader. </param>
        /// <param name="teamId">   The identifier of the team led by the leader. </param>

        public TeamLeader(string name, int id, int teamId)
        {
            this.name = name;
            this.id = id;
            this.teamId = teamId;
        }
    }
}
