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
    public partial class Back : Form
    {
        public Back()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.content.Text = "";
            this.msg.Text = "";
            this.startBtn.Hide();
        }

        public Back(int num)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            initScreen((Item)Setting.taskList[num]);
        }

        private void initScreen(Item item)
        {
        }
    }
}
