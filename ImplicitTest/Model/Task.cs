using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ImplicitTest.Model
{
    class Task
    {
        public int type;
        public string stimulus;
        public ArrayList choice;

        public Task()
        {
            type = 0;
            stimulus = "";
            choice = null;
        }

        public Task(int type, string stimulus)
        {
            this.type = type;
            this.stimulus = stimulus;
        }
    }
}
