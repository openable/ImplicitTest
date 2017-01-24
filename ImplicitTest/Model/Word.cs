using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitTest.Model
{
    class Word : System.Windows.Forms.Button
    {
        public double gazeTime;
        private bool sequential = false;
        private double starTime;
        public string value;

        public Word()
        {
            gazeTime = 0.0;
            starTime = 0.0;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            UseVisualStyleBackColor = true;
        }

        public Word(string text, bool img)
        {
            gazeTime = 0.0;
            starTime = 0.0;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            UseVisualStyleBackColor = true;
            if (!img) this.Text = text;
            this.value = text;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Malgun Gothic", Setting.fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.Black;
        }

        public bool isGazeHit(double time, double x, double y)
        {
            bool isHit = false;
            if ((this.Location.X - Setting.xBuffer) < x
                && (this.Location.X + this.Size.Width + Setting.xBuffer) > x
                && (this.Location.Y - Setting.yBuffer) < y
                && (this.Location.Y + this.Size.Height + Setting.yBuffer) > y)
            {
                isHit = true;
                if (!sequential) {
                    sequential = true;
                    starTime = time;
                }
                else
                {
                    gazeTime = gazeTime + (time - starTime);
                    starTime = time;
                }
            }
            else
            {
                sequential = false;
            }
                
            return isHit;
        }
    }
}
