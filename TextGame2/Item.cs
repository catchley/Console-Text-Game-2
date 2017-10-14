using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame2
{
    class Item
    {
        public int location { get; set; }
        public bool isOnFire { get; set; } = false;
        public bool isBeingCarried { get; set; } = false;
        public string name { get; set; }
        public bool isWarm { get; set; } = false;
        public bool isCold { get; set; } = false;
        public bool isWet { get; set; } = false;
        public bool isFull { get; set; } = false;
        public bool isTurnedOn { get; set; } = false;
    }
}
