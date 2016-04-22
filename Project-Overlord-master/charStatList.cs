using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Pathfinder statistics payload struct
    public class statBlockPF {
        public int blockID = -1;
        public string playerName = "";
        public string name = "New Character";
        public string raceClass = "";
        public int STR = 10, CON = 10, DEX = 10,
                   INT = 10, WIS = 10, CHA = 10;
        public int AC = 0, touchAC = 0, flatAC = 0,
                   fort = 0, reflex = 0, will = 0,
                   speed = 0, reach = 0, initiaitive = 0,
                   BAB = 0, CMB = 0, CMD = 0;
        public int sklAcro = 0, sklAppr = 0, sklBluf = 0, sklClim = 0,
                   sklCraf = 0, sklDipl = 0, sklDisa = 0, sklDisg = 0,
                   sklEsca = 0, sklFly = 0, sklHand = 0, sklHeal = 0,
                   sklInti = 0, sklLing = 0, sklPerc = 0, sklPerf = 0,
                   sklProf = 0, sklRide = 0, sklSens = 0, sklSlei = 0,
                   sklSpel = 0, sklStel = 0, sklSurv = 0, sklSwim = 0,
                   sklUseD = 0;
        public int knwArca = 0, knwDung = 0, knwEngi = 0, knwGeog = 0,
                   knwHist = 0, knwLoca = 0, knwNatu = 0, knwNobi = 0,
                   knwPlan = 0, knwReli = 0;
        public List<string> classFeat = new List<string>();
        public List<string> equipment = new List<string>();
        public List<string> spells = new List<string>();

        public statBlockPF() {

        }

        public statBlockPF(int id, string newName, string pName, string race) {
            blockID = id;
            name = newName;
            playerName = pName;
            raceClass = race;
        }

    }

    class charStatList {
        LinkedList<statBlockPF> charList;

        private statBlockPF error = new statBlockPF(-1, "<!>ERROR", "<!>ERROR", "<!>ERROR");

        public void clearList () {
            charList.Clear();
        }

        //Get first payload in list
        public statBlockPF getFirst() {

            if (charList.Count != 0) {
                return charList.First.Value;
            } else {
                return error;
            }

        }

        //Get payload stored next after specified blockID
        public statBlockPF getNext(int targetID) {
            LinkedListNode<statBlockPF> current = charList.First;

            while (current != null) {

                if (current.Value.blockID == targetID) {
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

        //Get payload stored next before specified blockID
        public statBlockPF getPrev(int targetID) {
            LinkedListNode<statBlockPF> current = charList.First;

            while (current != null) {

                if (current.Value.blockID == targetID) {
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
        public statBlockPF getLast() {

            if (charList.Count != 0) {
                return charList.Last.Value;
            } else {
                return error;
            }

        }

        //Add specified payload to list or update entry
        public Boolean addEntry(statBlockPF newBlock) {

            if (charList.Count == 0) {
                charList.AddFirst(newBlock);
                return true;
            }

            LinkedListNode<statBlockPF> current = charList.First;

            while (current != null) {

                if (current.Value.blockID == newBlock.blockID) {               //If updating an entry
                    current.Value = newBlock;
                    return true;
                } else if (current.Value.blockID > newBlock.blockID) {         //Inserting within list
                    charList.AddBefore(current, newBlock);
                    return true;
                } else if (current == charList.Last) {                         //Inserting at end of list
                    charList.AddAfter(current, newBlock);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Remove payload with specified ID from list
        public Boolean removeEntry(int targetID) {
            LinkedListNode<statBlockPF> current = charList.First;

            while (current != null) {

                if (current.Value.blockID == targetID) {
                    charList.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Retrieve payload with specified 
        public statBlockPF retrieveEntry(int targetID) {
            LinkedListNode<statBlockPF> current = charList.First;

            while (current != null) {

                if (current.Value.blockID == targetID) {
                    return current.Value;
                }

                current = current.Next;
            }

            return error;
        }

    }
}
