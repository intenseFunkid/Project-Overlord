using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Table entry payload struct
    struct tableEntry
    {
        public int entryID;         //Numeric identifier
        public string entry;        //
        public int weight;          //

        //Payload constructor
        public tableEntry(int id, string ent, int wgt)
        {
            entryID = id;
            entry = ent;
            weight = wgt;
        }
    }

    //Table payload class     ///      ///      ///      ///      ///
    class randomTable
    {
        private int tableID;
        private string title;
        private int totalWeight;
        private LinkedList<tableEntry> userTable = new LinkedList<tableEntry>();

        private tableEntry error = new tableEntry(-1, "ERROR", -1);

        //Table constructor
        public randomTable(int newID)
        {
            tableID = newID;
        }

        public int getID()
        {
            return tableID;
        }

        public void setTitle(string newTitle)
        {
            title = newTitle;
        }

        public string getTitle()
        {
            return title;
        }

        public tableEntry getFirst()
        {
            if (userTable.Count != 0)
            {
                return userTable.First.Value;
            }
            else
            {
                return error;
            }
        }

        public tableEntry getNext(int targetID)
        {
            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null)
            {

                if (current.Value.entryID == targetID)
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

        public tableEntry getLast()
        {
            if (userTable.Count != 0)
            {
                return userTable.Last.Value;
            }
            else
            {
                return error;
            }
        }

        //Add entry to table
        public Boolean addEntry(tableEntry newEntry)
        {

            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null)
            {

                if (newEntry.entryID == current.Value.entryID)
                {
                    current.Value = newEntry;
                    return true;
                }
            }

            userTable.AddLast(newEntry);
            return false;
        }

        //Remove entry with specified ID from table
        public Boolean removeEntry(int targetID)
        {
            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null)
            {

                if (current.Value.entryID == targetID)
                {
                    userTable.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Retrieve entry with specified ID
        public tableEntry retrieveEntry(int targetID)
        {
            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null)
            {

                if (current.Value.entryID == targetID)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return error;
        }

        //Roll for value on table
        public string rollTable()
        {
            if (userTable.Count == 0)
            {
                return ("ERROR >> EMPTY TABLE");
            }

            LinkedListNode<tableEntry> current = userTable.First;
            string[] outTable = new string[totalWeight];
            int outIndex = 0;
            Random random = new Random();


            while (current != null)
            {

                for (int i = 0; i < current.Value.weight; i++)
                {
                    outTable[outIndex] = current.Value.entry;
                    outIndex++;
                }

                current = current.Next;
            }

            return outTable[random.Next(0, totalWeight)];
        }
    }


    //Table Index class     ///      ///      ///      ///      ///
    class randomTableList
    {
        private LinkedList<randomTable> tableIndex = new LinkedList<randomTable>();


        public int getFirstID()
        {
            return tableIndex.First.Value.getID();
        }

        public int getLastID()
        {
            return tableIndex.Last.Value.getID();
        }

        //Add table to index
        public Boolean addTable(randomTable newTable)
        {
            return true;
        }

        //Remove table with specified ID from index
        public Boolean removeEntry(int targetID)
        {
            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null)
            {

                if (current.Value.getID() == targetID)
                {
                    tableIndex.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Roll for value on specified table
        public string rollTable(int targetID)
        {
            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null)
            {

                if (current.Value.getID() == targetID)
                {
                    return current.Value.rollTable();
                }

                current = current.Next;
            }

            return "ERROR";
        }
    }
}
