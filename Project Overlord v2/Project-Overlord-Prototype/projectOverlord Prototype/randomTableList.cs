using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Table entry payload
    struct tableEntry {
        public int entryID;
        public string entry;
        public int weight;

        //Payload constructor
        public tableEntry (int id, string ent, int wgt) {
            entryID = id;
            entry = ent;
            weight = wgt;
        }
    }

    //Table payload class
    class randomTable {
        private int tableID;
        private string title;
        private int totalWeight;
        private LinkedList<tableEntry> userTable;

        private tableEntry error = new tableEntry(-1, "ERROR", -1);

        //Table constructor
        public randomTable(int newID) {
            
        }

        public int getID() {
            return tableID;
        }

        public void setTitle (string newTitle) {
            title = newTitle;
        }

        
        public string getTitle () {
            return title;
        }

        //Add entry to table
        public Boolean addEntry(tableEntry newEntry) {


            return true;
        }

        //Remove entry with specified ID from table
        public Boolean removeEntry(int targetID) {
            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null) {

                if (current.Value.entryID == targetID) {
                    userTable.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Retrieve entry with specified ID
        public tableEntry retrieveEntry(int targetID) {
            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null) {

                if (current.Value.entryID == targetID) {
                    return current.Value;
                }

                current = current.Next;
            }

            return error;
        }

        //Roll for value on table
        public string rollTable() {
            if (userTable.Count == 0) {
                return ("ERROR >> EMPTY TABLE");
            }

            LinkedListNode<tableEntry> current = userTable.First;

            while (current != null) {


                current = current.Next;
            }




            return "OH NO";
        }
    }


    //Table Index class
    class randomTableList {
        private LinkedList<randomTable> tableIndex;

        //Add table to index
        public Boolean addTable(randomTable newTable) {
            return true;
        }

        //Remove table with specified ID from index
        public Boolean removeEntry(int targetID) {
            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null) {

                if (current.Value.getID() == targetID) {
                    tableIndex.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Roll for value on specified table
        public string rollTable(int targetID) {
            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null) {

                if (current.Value.getID() == targetID) {
                    return current.Value.rollTable();
                }

                current = current.Next;
            }

            return "ERROR";
        }
    }
}
