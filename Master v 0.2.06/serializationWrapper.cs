using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    // Allows for custom classes to be used in serialization
    //

    // data from randomTable class and subclass tableEntry
    public class tableSerialization
    {
        public int tableID;
        public string title;
        public int totalWeight;

        //Lists to hold tableEntry data members list
        public List<string> entriesList = new List<string>();
        public List<int> weightsList = new List<int>();
    }

    //Top Level Serialization Class
    public class serializationWrapper
    {
        //List of character stat blocks
        public List<statBlockPF> charStatHolder = new List<statBlockPF>();

        //List of real life dates
        public List<dateEntry> dateHolder = new List<dateEntry>();

        public List<tableSerialization> tableHolder = new List<tableSerialization>();
    }
}
