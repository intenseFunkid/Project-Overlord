using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord {

    struct dateEntry {
        int dateID;             //yyyymmdd
        string planEntry;       //Planning notes
        string sessionEntry;    //Session notes

        int gameDateStartID;    //In-game time tracking
	    int gameDateEndID;      
    }


    class dateList {
        private LinkedList<dateEntry> list;
        private LinkedList<dateEntry> index;

        public Boolean addEntry (dateEntry newDate) {

            return true;
        }

    }

}
