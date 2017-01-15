using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitTest.Model
{
    class Word : System.Windows.Forms.Button
    {
        private double gazeTime;
        private string text;

        public Word()
        {
            gazeTime = 0.0;
        }

        public Word(string text)
        {
            gazeTime = 0.0;
            this.text = text;
        }

    }
}
