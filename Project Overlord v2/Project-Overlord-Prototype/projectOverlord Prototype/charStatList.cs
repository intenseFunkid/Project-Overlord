using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectOverlord
{
    //Pathfinder statistics payload struct
    struct statBlockPF {
        int blockID;
        string name;
        int STR, CON, DEX, INT, WIS, CHA;
        

    }

    class charStatList {
        LinkedList<statBlockPF> charList;

        
    }
}
