using System.Collections.Generic;
using Crew.Models;

namespace Crew.EventArgs
{
    public class CrewDataEventArgs : System.EventArgs
    {
        public CrewDataEventArgs(List<CrewMemberObject> crewMemberObjects)
        {
            CrewMemberObjects = crewMemberObjects;
        }

        public List<CrewMemberObject> CrewMemberObjects { get; }
    }
}