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

        public Word()
        {
            gazeTime = 0.0;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            UseVisualStyleBackColor = true;
        }

        public Word(string text)
        {
            gazeTime = 0.0;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            UseVisualStyleBackColor = true;
            this.Text = text;
        }

    }
}
