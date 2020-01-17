using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   Represents a team. </summary>
    ///
    /// <remarks>   Both internal and external teams are represented using this class.  </remarks>
    [Serializable]
    public class Team
    {
        private int id;
        private string location, name;
        private TeamLeader leader;

        
        /// <summary>   Gets or sets the identifier of the team. </summary>
        ///
        /// <value> The identifier of the team. </value>

        public int TeamId
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>   Gets or sets the leader. </summary>
        ///
        /// <value> The team leader. </value>

        public TeamLeader Leader
        {
            get { return leader; }
            set { leader = value; }
        }

        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location where the team is based. </value>

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name of the team. </value>

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Team() { }

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Sets the properties of the team. </remarks>
        ///
        /// <param name="id">       The identifier. </param>
        /// <param name="location"> The location where the team is based. </param>
        /// <param name="name">     The name of the team. </param>
        /// <param name="leader">   The team leader. </param>

        public Team(int id, string location, string name, TeamLeader leader)
        {
            this.location = location;
            this.name = name;
            this.id = id;
            this.leader = leader;
        }
    }
}
