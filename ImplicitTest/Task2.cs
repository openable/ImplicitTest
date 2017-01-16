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
    public partial class Task2 : Form
    {
        private GazePointDataStream lightlyFilteredGazeDataStream =
            Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
        private Word stimulus;
        private Word[] words = new Word[15];
        private int order = 1;
        private int max = 2;

        public Task2()
        {
            InitializeComponent();

            // 전체화면 만들기
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            initStimulus();

            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;
        }

        private void initStimulus()
        {
            taskNum.Text = "문항2-" + order;
            if (order == 1) {
                stimulus = new Word("문재인");
            }
            else if (order == 2)
            {
                stimulus = new Word("반기문");
            }
            stimulus.SetBounds((int)Setting.cStimulus.X, (int)Setting.cStimulus.Y, (int)Setting.sStimulus.X, (int)Setting.sStimulus.Y);
            this.Controls.Add(stimulus);

            for (int i = 0; i < 15; i++)
            {
                words[i] = new Word("단어 " + order + "-" + (i + 1));
                words[i].SetBounds((int)Setting.cWord[i].X, (int)Setting.cWord[i].Y, (int)Setting.sWord.X, (int)Setting.sWord.Y);
                words[i].Click += new System.EventHandler(this.word_Click);
                this.Controls.Add(words[i]);
            }
        }

        private void gazeDataStreamHandler(object sender, GazePointEventArgs e)
        {
            //            Console.WriteLine("{0}\t{1}\t{2}", e.Timestamp, e.X, e.Y);
            Graphics gr = this.CreateGraphics();
            Brush br = new SolidBrush(Color.Red);
            gr.FillRectangle(br, (int)e.X, (int)e.Y, 5, 5);
            gr.Dispose();

            for (int i = 0; i < 15; i++)
            {
                if (words[i].isGazeHit(e.Timestamp, (int)e.X, (int)e.Y))
                {
//                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", e.Timestamp, e.X, e.Y, words[i].Text);
                    return;
                }
            }

        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            lightlyFilteredGazeDataStream.Next -= gazeDataStreamHandler;
        }

        private void word_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();

            this.Controls.Remove(stimulus);

            for (int i = 0; i < 15; i++)
            {
                this.Controls.Remove(words[i]);
                Console.WriteLine("{0}\t{1}", words[i].Text, words[i].gazeTime);
            }

            if (order < max)
            {
                order = order + 1;
                initStimulus();
            }
            else
                this.Close();
        }
    }
}
