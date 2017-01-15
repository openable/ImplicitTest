using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplicitTest
{
    public partial class Main : Form
    {
        private Task0 task0;

        public Main()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            task0 = new Task0();
            task0.Show();
        }
    }
}
