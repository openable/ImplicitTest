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

using ImplicitTest.Model;

namespace ImplicitTest
{
    public partial class Task1 : Form
    {
        private GazePointDataStream lightlyFilteredGazeDataStream =
            Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
        private Word[] words = new Word[15];

        public Task1()
        {
            InitializeComponent();

            // 전체화면 만들기
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            for (int i = 0; i < 15; i++)
            {
                words[i] = new Word();
                words[i].SetBounds((int)Setting.cWord[i].X, (int)Setting.cWord[i].Y, (int)Setting.sWord.X, (int)Setting.sWord.Y);
                this.Controls.Add(words[i]);
            }
            
            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;
        }

        private void gazeDataStreamHandler(object sender, GazePointEventArgs e)
        {
            //            Console.WriteLine("{0}\t{1}\t{2}", e.Timestamp, e.X, e.Y);
            Graphics gr = this.CreateGraphics();
            Brush br = new SolidBrush(Color.Red);
            gr.FillRectangle(br, (int)e.X, (int)e.Y, 5, 5);
            gr.Dispose();
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            lightlyFilteredGazeDataStream.Next -= gazeDataStreamHandler;
        }
    }
}
