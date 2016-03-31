using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord {

    //Payload struct
    struct gameDateEntry {
        public int gameDateID;      
        public string entry;

        //Payload constructor
        public gameDateEntry(int id, string ent) {
            gameDateID = id;
            entry = ent;
        }
    }

    class gameDateList {
        private LinkedList<gameDateEntry> gDateList;
        //private LinkedList<gameDateEntry> index;
        private gameDateEntry gDateError = new gameDateEntry(-1, "ERROR");

        //Add specified payload to list
        public Boolean addEntry(gameDateEntry newDate) {

            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null) {

                if (current.Value.gameDateID == newDate.gameDateID) {
                    current.Value = newDate;
                    return true;
                } else if (current.Value.gameDateID > newDate.gameDateID) {
                    gDateList.AddBefore(current, newDate);
                    return true;
                } else if (current == gDateList.Last) {
                    gDateList.AddAfter(current, newDate);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Remove payload with specified ID from list
        public Boolean removeEntry(int targetID) {
            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null) {

                if (current.Value.gameDateID == targetID) {

                    gDateList.Remove(current);
                    return true;
                }

                current = current.Next;
            }
            
            return false;
        }

        //Retrieve payload with specified 
        public gameDateEntry retrieveEntry(int targetID) {
            LinkedListNode<gameDateEntry> current = gDateList.First;
            gameDateEntry target;

            while (current != null) {

                if (current.Value.gameDateID == targetID) {
                    target = current.Value;
                    return target;
                }

                current = current.Next;
            }

            target = gDateError;

            return target;
        }

    }
}
