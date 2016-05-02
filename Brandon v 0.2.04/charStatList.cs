using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Pathfinder statistics payload struct
    public class statBlockPF {
        public int blockID;
        public string playerName;
        public string name = "New Character";
        public string raceClass = "";
        public int STR, CON, DEX, INT, WIS, CHA;
        public int AC, touchAC, flatAC, fort, reflex, will, speed, reach, initiative, BAB, CMB, CMD;
        public int sklAcro, sklAppr, sklBluf, sklClim,
                   sklCraf, sklDipl, sklDisa, sklDisg,
                   sklEsca, sklFly, sklHand, sklHeal,
                   sklInti, sklLing, sklPerc, sklPerf,
                   sklProf, sklRide, sklSens, sklSlei,
                   sklSpel, sklStel, sklSurv, sklSwim,
                   sklUseD;
        public int knwArca, knwDung, knwEngi, knwGeog,
                   knwHist, knwLoca, knwNatu, knwNobi,
                   knwPlan, knwReli;
        public List<string> classFeat = new List<string>();
        public List<string> equipment = new List<string>();
        public List<string> spells = new List<string>();

        public statBlockPF() {
            blockID = -1; // <------ Is this really needed?
            playerName = "Unknown Player";
            name = "New Character";
            raceClass = "Unknown Race & Class";
            STR = CON = DEX = INT = WIS = CHA = 10;
            AC = touchAC = flatAC = fort = reflex = will = speed = reach = initiative = BAB = CMB = CMD = 0;
            //Initialize Non-Knowledge Skills
            sklAcro = sklAppr = sklBluf = sklClim = 0;
            sklCraf = sklDipl = sklDisa = sklDisg = 0;
            sklEsca = sklFly = sklHand = sklHeal = 0;
            sklInti = sklLing = sklPerc = sklPerf = 0;
            sklProf = sklRide = sklSens = sklSlei = 0;
            sklSpel = sklStel = sklSurv = sklSwim = 0;
            sklUseD = 0;
            //Initialize Knowledge Skills
            knwArca = knwDung = knwEngi = knwGeog = 0;
            knwHist = knwLoca = knwNatu = knwNobi = 0;
            knwPlan = knwReli = 0;
        }

        public statBlockPF(int id, string newName, string pName, string race) {
            blockID = id;
            name = newName;
            playerName = pName;
            raceClass = race;
            //Initialize Non-Knowledge Skills
            STR = CON = DEX = INT = WIS = CHA = 10;
            AC = touchAC = flatAC = fort = reflex = will = speed = reach = initiative = BAB = CMB = CMD = 0;
            sklAcro = sklAppr = sklBluf = sklClim = 0;
            sklCraf = sklDipl = sklDisa = sklDisg = 0;
            sklEsca = sklFly = sklHand = sklHeal = 0;
            sklInti = sklLing = sklPerc = sklPerf = 0;
            sklProf = sklRide = sklSens = sklSlei = 0;
            sklSpel = sklStel = sklSurv = sklSwim = 0;
            sklUseD = 0;
            //Initialize Knowledge Skills
            knwArca = knwDung = knwEngi = knwGeog = 0;
            knwHist = knwLoca = knwNatu = knwNobi = 0;
            knwPlan = knwReli = 0;
        }

    }

    class charStatList {
        LinkedList<statBlockPF> charList = new LinkedList<statBlockPF>();

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

        public int getLength()
        {
            return charList.Count();
        }
    }
}
