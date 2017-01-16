﻿using System;
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
        public static PointF sStimulus;
        public static PointF cStimulus;
        public static PointF aWord;
        public static float xInterval;
        public static float yInterval;
        public static float xBuffer;
        public static float yBuffer;
        public static PointF sWord;
        public static PointF[] cWord = new PointF[15];
        
    }
}