using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImplicitTest.Model
{
    class Setting
    {
        public static int SCREEN_WIDTH;
        public static int SCREEN_HEIGHT;

        public static PointF margin;
        public static PointF cStimulus;
        public static PointF[] cWord = new PointF[15];
        public static SizeF interval;
        public static SizeF buffer;
    }
}
