using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Table entry payload struct
    public class tableEntry
    {
        public string entry;        //
        public int weight;          //

        //Payload constructor
        public tableEntry(string ent, int wgt)
        {
            entry = ent;
            weight = wgt;
        }
    }

    /*__________________________________________________________*/
    /*Table Payload class///////////////////////////////////////*/
    /*__________________________________________________________*/
    public class randomTable
    {
        private int tableID;
        private string title;
        private int totalWeight;
        private Boolean rollOnNewDay = false;
        private List<tableEntry> userTable = new List<tableEntry>();

        private tableEntry error = new tableEntry("<!>ERROR", -1);

        public void clearTable()
        {
            userTable.Clear();
        }

        //Table constructor
        public randomTable(int newID)
        {
            tableID = newID;
        }

        public tableEntry getFirst()
        {
            if (userTable.Count != 0)
            {
                return userTable[0];
            }
            else
            {
                return error;
            }
        }

        public tableEntry getLast()
        {
            if (userTable.Count != 0)
            {
                return userTable[userTable.Count - 1];
            }
            else
            {
                return error;
            }
        }

        //Get Next tableEntry in userList
        public tableEntry getNext(int index)
        {
            //Table is empty
            if (this.getLength() == 0)
            {
                return error;
            }
            //Table is not empty
            else
            {
                //index is last entry in list
                if (index == this.getLength() - 1)
                {
                    return error;
                }
                else
                {
                    return userTable[index + 1];
                }
            }
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

        public int getLength()
        {
            return userTable.Count;
        }

        public Boolean shouldRoll()
        {
            return rollOnNewDay;
        }

        //Add entry to table
        public Boolean addEntry(tableEntry newEntry)
        {

            userTable.Add(newEntry);
            calcWeight();
            return true;
        }

        //Remove entry with specified value from table
        public Boolean removeEntry(string targetEntry)
        {
            for (int i = 0; i < userTable.Count; i++)
            {
                if (userTable[i].entry == targetEntry)
                {
                    userTable.Remove(userTable[i]);
                    calcWeight();
                    return true;
                }
            }

            return false;
        }

        //Retrieve entry with specified value
        public tableEntry retrieveEntry(string targetEntry)
        {
            for (int i = 0; i < userTable.Count; i++)
            {
                if (userTable[i].entry == targetEntry)
                {
                    return userTable[i];
                }
            }

            return error;
        }

        public bool updateEntry(string oldEntry, string newEntry, int newWeight)
        {

            if (this.getLength() != 0)
            {
                int index = 0;

                while (index < this.getLength() && userTable[index].entry != oldEntry)
                {
                    index++;
                }
                /*for (int cycle = 0; cycle < this.getLength() && userTable[cycle].entry != oldEntry; cycle++)
                {

                    index = this.
                }*/
                //Determine if oldEntry exists
                //If so update and return true
                if (userTable[index].entry == oldEntry)
                {
                    userTable[index].entry = newEntry;
                    userTable[index].weight = newWeight;
                    return true;
                }
                //Old entry does not exist
                else
                {
                    //Create new entry with specified info
                    tableEntry newTableEntry = new tableEntry(newEntry, newWeight);
                    this.addEntry(newTableEntry);
                    return true;
                }
            }
            else //Table is empty
            {
                return false;
            }
        }

        //Roll for value on table
        public string rollTable()
        {
            if (userTable.Count == 0)
            {
                return ("ERROR >> EMPTY TABLE");
            }

            string[] outTable = new string[totalWeight];
            int outIndex = 0;
            Random random = new Random();


            for (int i = 0; i < userTable.Count; i++)
            {
                for (int j = 0; j < userTable[i].weight; j++)
                {
                    outTable[outIndex] = userTable[i].entry;
                    outIndex++;
                }
            }

            return outTable[random.Next(0, totalWeight)];
        }

        //Calculates total weight of table
        private void calcWeight()
        {
            totalWeight = 0;

            for (int i = 0; i < userTable.Count; i++)
            {
                totalWeight += userTable[i].weight;
            }
        }

        public int getTotalWeight()
        {
            return totalWeight;
        }
    }

    /*__________________________________________________________*/
    /*Table Index class/////////////////////////////////////////*/
    /*__________________________________________________________*/
    class randomTableList
    {
        private LinkedList<randomTable> tableIndex = new LinkedList<randomTable>();
        //private int lastID = 0;
        private randomTable error = new randomTable(-1);
        //private randomTable activeTable;

        public void clearList()
        {
            tableIndex.Clear();
            //lastID = 0;
        }

        public randomTable getFirst()
        {
            if (tableIndex.Count() == 0)
            {
                return error;
            }
            else
            {
                return tableIndex.First.Value;
            }
        }

        public randomTable getLast()
        {
            if (tableIndex.Count() == 0)
            {
                return error;
            }
            else
            {
                return tableIndex.Last.Value;
            }
        }

        public randomTable getNext(int targetID)
        {

            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null)
            {
                if (current.Value.getID() == targetID)
                {
                    if (current.Next != null)
                    {
                        return current.Next.Value;
                    }
                    else
                    {
                        return error;
                    }
                }
                current = current.Next;
            }
            return error;
        }

        /* public int getLastID() {
             return lastID;
         }*/

        //Add table to tableIndex linked list. Must increment tableID in event
        public Boolean addTable(randomTable newTable)
        {
            tableIndex.AddLast(newTable);
            //lastID++;
            return true;
        }

        //Remove table with specified ID from index
        public Boolean removeTable(int targetID)
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

        //Retrieve table with specified ID from index
        public randomTable retrieveTable(int targetID)
        {
            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null)
            {

                if (current.Value.getID() == targetID)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return error;
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

            return "<!>ERROR";
        }

        public int getNumOfTables()
        {
            return tableIndex.Count();
        }
    }
}
