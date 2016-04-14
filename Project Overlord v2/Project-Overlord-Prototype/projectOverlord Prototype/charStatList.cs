using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Pathfinder statistics payload struct
    public struct statBlockPF {
        public int blockID;
        public string name;
        public int STR, CON, DEX, INT, WIS, CHA;
        

    }

    class charStatList {
        LinkedList<statBlockPF> charList;

        
    }
}
