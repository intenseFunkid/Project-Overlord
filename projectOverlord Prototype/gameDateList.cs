using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{

    //Payload struct
    public struct gameDateEntry
    {
        public int gameDateID;      //Numeric identifier 
        public string entry;        //Notes for game day

        //Payload constructor
        public gameDateEntry(int id, string ent)
        {
            gameDateID = id;
            entry = ent;
        }
    }

    class gameDateList
    {
        private LinkedList<gameDateEntry> gDateList = new LinkedList<gameDateEntry>();
        //private LinkedList<gameDateEntry> index;
        private gameDateEntry error = new gameDateEntry(-1, "<!>ERROR");

        //Get first payload in list
        public gameDateEntry getFirst()
        {

            if (gDateList.Count != 0)
            {
                return gDateList.First.Value;
            }
            else
            {
                return error;
            }

        }

        //Get payload stored next after specified gameDateID
        public gameDateEntry getNext(int targetID)
        {
            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null)
            {

                if (current.Value.gameDateID == targetID)
                {
                    if (current.Next != null)
                    {
                        return current.Next.Value;
                    }
                    else
                    {
                        break;
                    }
                }

                current = current.Next;
            }
            return error;
        }

        //Get last payload in list
        public gameDateEntry getLast()
        {

            if (gDateList.Count != 0)
            {
                return gDateList.Last.Value;
            }
            else
            {
                return error;
            }

        }

        //Add specified payload to list
        public Boolean addEntry(gameDateEntry newDate)
        {

            if (gDateList.Count == 0)
            {
                gDateList.AddFirst(newDate);
                return true;
            }

            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null)
            {

                if (current.Value.gameDateID == newDate.gameDateID)
                {           //If updating an entry
                    current.Value = newDate;
                    return true;
                }
                else if (current.Value.gameDateID > newDate.gameDateID)
                {     //Inserting within list
                    gDateList.AddBefore(current, newDate);
                    return true;
                }
                else if (current == gDateList.Last)
                {                         //Inserting at end of list
                    gDateList.AddAfter(current, newDate);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Remove payload with specified ID from list
        public Boolean removeEntry(int targetID)
        {
            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null)
            {

                if (current.Value.gameDateID == targetID)
                {
                    gDateList.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Retrieve payload with specified 
        public gameDateEntry retrieveEntry(int targetID)
        {
            LinkedListNode<gameDateEntry> current = gDateList.First;

            while (current != null)
            {

                if (current.Value.gameDateID == targetID)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return error;
        }

    }
}
