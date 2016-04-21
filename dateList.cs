﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord {

    //Payload struct
    public struct dateEntry {
        public int dateID;             //yyyymmdd
        public string planEntry;       //Planning notes
        public string sessionEntry;    //Session notes

        public int gameDateStartID;    //In-game time tracking
        public int gameDateEndID;  
    
        //Payload Constructor
        public dateEntry(int id, string pent, string sent, int gstart, int gend) {
            dateID = id;
            planEntry = pent;
            sessionEntry = sent;
            gameDateStartID = gstart;
            gameDateEndID = gend;
        }
    }

    
    class dateList {
        private LinkedList<dateEntry> dList = new LinkedList<dateEntry>();
        /*private LinkedList<dateEntry> index;*/
        private dateEntry error = new dateEntry(-1, "<!>ERROR", "<!>ERROR", -1, -1);

        //Get first payload in list
        public dateEntry getFirst() {

            if (dList.Count != 0) {
                return dList.First.Value;
            } else {
                return error;
            }

        }

        //Get payload stored next after specified dateID
        public dateEntry getNext(int targetID) {
            LinkedListNode<dateEntry> current = dList.First;

            while (current != null) {

                if (current.Value.dateID == targetID) {
                    if (current.Next != null) {
                        return current.Next.Value;
                    } else {
                        break;
                    }
                }

                current = current.Next;
            }
            return error;
        }

        //Get payload stored next before specified dateID
        public dateEntry getPrev(int targetID) {
            LinkedListNode<dateEntry> current = dList.First;

            while (current != null) {

                if (current.Value.dateID == targetID) {
                    if (current.Previous != null) {
                        return current.Previous.Value;
                    } else {
                        break;
                    }
                }

                current = current.Next;
            }
            return error;
        }

        //Get last payload in list
        public dateEntry getLast() {

            if (dList.Count != 0) {
                return dList.Last.Value;
            } else {
                return error;
            }

        }
        
        //Add specified payload to list
        public Boolean addEntry (dateEntry newDate) {

            if (dList.Count == 0) {
                dList.AddFirst(newDate);
                return true;
            }

            LinkedListNode<dateEntry> current = dList.First;
            
            while (current != null) {

                if (current.Value.dateID == newDate.dateID) {           //If updating an entry
                    current.Value = newDate;
                    return true;
                } else if (current.Value.dateID > newDate.dateID) {     //Inserting within list
                    dList.AddBefore(current, newDate);
                    return true;
                } else if (current == dList.Last) {                     //Inserting at end of list
                    dList.AddAfter(current, newDate);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Remove payload with specified ID from list
        public Boolean removeEntry (int targetID) {
            LinkedListNode<dateEntry> current = dList.First;

            while (current != null) {

                if (current.Value.dateID == targetID) {
                    dList.Remove(current);
                    return true;
                }

                current = current.Next;
            }
            
            return false;
        }

        //Retrieve payload with specified
        public dateEntry retrieveEntry(int targetID) {
            LinkedListNode<dateEntry> current = dList.First;
            dateEntry target;

            while (current != null) {

                if (current.Value.dateID == targetID) {
                    target = current.Value;
                    return target;
                }

                current = current.Next;
            }

            target = error;

            return target;
        }

        /*
        public void rebuildIndex() {
            LinkedListNode<dateEntry> current = dList.First;
            while (current != null) {

                current = current.Next;

            }

        }*/

    }

}
