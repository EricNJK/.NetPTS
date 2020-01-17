using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   Represents a customer ofthe company. </summary>
    /// 
    /// <remarks>   This is a subclass of <see cref="User">User superclass.</see>/></remarks>
    [Serializable]
    public class Customer : User
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Customer() { }

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Takes two arguments and assigns them to the inherited variables.</remarks>
        ///
        /// <param name="name"> The name of the customer. </param>
        /// <param name="id">   The identifier . </param>

        public Customer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
