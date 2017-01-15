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

            Setting.SCREEN_WIDTH = SystemInformation.PrimaryMonitorSize.Width;
            Setting.SCREEN_HEIGHT = SystemInformation.PrimaryMonitorSize.Height;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            task1 = new Task1();
            task1.Show();
        }
    }
}
