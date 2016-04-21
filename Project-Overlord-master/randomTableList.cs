using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Table entry payload struct
    public struct tableEntry {
        public string entry;        //
        public int weight;          //

        //Payload constructor
        public tableEntry (string ent, int wgt) {
            entry = ent;
            weight = wgt;
        }
    }

     /*__________________________________________________________*/
    /*Table Payload class///////////////////////////////////////*/
   /*__________________________________________________________*/
    public class randomTable {
        private int tableID;
        private string title;
        private int totalWeight;
        private Boolean rollOnNewDay = false;
        private List<tableEntry> userTable = new List<tableEntry>();

        private tableEntry error = new tableEntry("<!>ERROR", -1);

        //Table constructor
        public randomTable(int newID) {
            tableID = newID;
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

        public int getLength () {
            return userTable.Count;
        }

        public Boolean shouldRoll() {
            return rollOnNewDay;
        }

        public tableEntry getFirst() {
            if (userTable.Count != 0) {
                return userTable[0];
            } else {
                return error;
            }
        }

        public tableEntry getLast() {
            if (userTable.Count != 0) {
                return userTable[userTable.Count -1];
            } else {
                return error;
            }
        }

        //Add entry to table
        public Boolean addEntry(tableEntry newEntry) {

            userTable.Add(newEntry);
            calcWeight();
            return true;
        }

        //Remove entry with specified value from table
        public Boolean removeEntry(string targetEntry) {
            for (int i = 0; i < userTable.Count; i++) {
                if (userTable[i].entry == targetEntry) {
                    userTable.Remove(userTable[i]);
                    return true;
                }
            }

            return false;
        }

        //Retrieve entry with specified value
        public tableEntry retrieveEntry(string targetEntry) {
            for (int i = 0; i < userTable.Count; i++) {
                if (userTable[i].entry == targetEntry) {
                    return userTable[i];
                }
            }

            return error;
        }

        //Roll for value on table
        public string rollTable() {
            if (userTable.Count == 0) {
                return ("ERROR >> EMPTY TABLE");
            }

            string[] outTable = new string[totalWeight];
            int outIndex = 0;
            Random random = new Random();
            

            for (int i = 0; i < userTable.Count; i++) {
                for (int j = 0; j < userTable[i].weight; j++) {
                    outTable[outIndex] = userTable[i].entry;
                    outIndex++;
                }
            }

            return outTable[random.Next(0, totalWeight)];
        }

        //Calculates total weight of table
        private void calcWeight () {
            totalWeight = 0;

            for (int i = 0; i < userTable.Count; i++) {
                totalWeight += userTable[i].weight;
            }
        }
    }

     /*__________________________________________________________*/
    /*Table Index class/////////////////////////////////////////*/
   /*__________________________________________________________*/
    class randomTableList {
        private LinkedList<randomTable> tableIndex = new LinkedList<randomTable>();
        private int lastID = 0;
        private randomTable error = new randomTable(-1);
        private randomTable activeTable;


        public randomTable getFirst() {
            activeTable = tableIndex.First.Value;
            return activeTable;
        }

        public randomTable getLast() {
            activeTable = tableIndex.Last.Value;
            return activeTable;
        }

        public randomTable getNext() {
            activeTable = retrieveTable(activeTable.getID());
            return activeTable;
        }

        public int getLastID() {
            return lastID;
        }

        //Add table to index
        public Boolean addTable(randomTable newTable) {
            tableIndex.AddLast(newTable);
            lastID++;
            return true;
        }

        //Update existing table in index
        public Boolean updateTable() {



            return false;
        }

        //Remove table with specified ID from index
        public Boolean removeTable(int targetID) {
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

        //Retrieve table with specified ID from index
        public randomTable retrieveTable(int targetID) {
         /*   if (activeTable.getID() == targetID) {
                return activeTable;
            }*/

            LinkedListNode<randomTable> current = tableIndex.First;

            while (current != null) {

                if (current.Value.getID() == targetID) {
                    activeTable = current.Value;
                    break;
                }

                current = current.Next;
            }

            return activeTable;
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

            return "<!>ERROR";
        }

        
    }
}
