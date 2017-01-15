using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EyeXFramework;
using Tobii.EyeX.Framework;

namespace ImplicitTest
{
    public partial class Task0 : Form
    {
        private int SCREEN_WIDTH = SystemInformation.PrimaryMonitorSize.Width;
        private int SCREEN_HEIGHT = SystemInformation.PrimaryMonitorSize.Height;

        private GazePointDataStream lightlyFilteredGazeDataStream =
            Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

        public Task0()
        {
            InitializeComponent();

            // 전체화면 만들기
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;
        }

        private void gazeDataStreamHandler(object sender, GazePointEventArgs e)
        {
            Console.WriteLine("{0}\t{1}\t{2}", e.Timestamp, e.X, e.Y);
        }
    }
}
