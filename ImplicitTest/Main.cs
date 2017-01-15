using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImplicitTest.Model;

namespace ImplicitTest
{
    public partial class Main : Form
    {
        private Task1 task1;

        public Main()
        {
            InitializeComponent();
            setCoordinate();
        }

        private void setCoordinate()
        {
            Setting.SCREEN_WIDTH = SystemInformation.PrimaryMonitorSize.Width;
            Setting.SCREEN_HEIGHT = SystemInformation.PrimaryMonitorSize.Height;

            Setting.margin = new PointF(30, 30);
            Setting.sStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.margin.X * 2) / 5.0),
                (float)((Setting.SCREEN_HEIGHT - Setting.margin.Y * 2) / 10.0));
            Setting.cStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.sStimulus.X) / 2.0),
                (float)(Setting.margin.Y));

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            task1 = new Task1();
            task1.Show();
        }
    }
}
