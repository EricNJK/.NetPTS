using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSLibrary
{
    /// <summary>   Enumeration of values that represent status. </summary>
    ///
    /// <remarks>   These values show the progress of a task or subtask. </remarks>

    public enum Status
    {
        /// <summary>   Task is ready but not commenced. </summary>
        ReadyToStart = 1,
        /// <summary>   Task is being executed. </summary>
        InProgress = 2,
        /// <summary>   Task is finished. </summary>
        Completed = 3,
        /// <summary>   Task is waiting for a preceding one to be completed. </summary>
        WaitingForPredecessor = 4
    }
}
