using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ImplicitTest.Model
{
    class Item
    {
        public int type;
        public string stimulus;
        public ArrayList choice;

        public Item()
        {
            type = 0;
            stimulus = "";
            choice = null;
        }

        public Item(int type, string stimulus)
        {
            this.type = type;
            this.stimulus = stimulus;
        }
    }
}
