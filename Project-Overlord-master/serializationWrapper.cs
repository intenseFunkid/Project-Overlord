using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    // Allows for custom classes to be used in serialization of 
    // data from randomTable class and subclass tableEntry


    //Holds the data for the table list
    public class tableSerialization
    {
        public int tableID;
        public string title;
        public int totalWeight;
        public Boolean rollOnNewDay;
    }

    //Holds the data for the individual entries of the tables
    public class tableEntrySerialization
    {
        public int tableID;
        public int entryID;
        public int entry;
        public int weight;
    }

    //Top Level Serialization Class
    public class serializationWrapper
    {
        //List of game Dates
        public List<gameDateEntry> gameDateHolder = new List<gameDateEntry>();

        //List of character stat blocks
        public List<statBlockPF> charStatHolder = new List<statBlockPF>();

        //List of real life dates
        public List<dateEntry> dateHolder = new List<dateEntry>();

        public List<randomTable> tableHolder = new List<randomTable>();

        //List of random table entries
        //public List<tableSerialization> tableHolder = new List<tableSerialization>();

        //public List<tableEntrySerialization> tableEntryHolder = new List<tableEntrySerialization>();
    }
}
