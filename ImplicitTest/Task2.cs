using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using EyeXFramework;
using Tobii.EyeX.Framework;

using ImplicitTest.Model;

namespace ImplicitTest
{
    public partial class Task2 : Form
    {
        private GazePointDataStream lightlyFilteredGazeDataStream =
            Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
        private int current;
        private Word stimulus;
        private Word[] choice = new Word[2];
        Stopwatch sw = new Stopwatch();

        public Task2(int num)
        {
            InitializeComponent();

            // 전체화면 만들기
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            current = num + 1;
            taskNum.Text = "문항 " + (current);

            Setting.rawFile.WriteLine("==========================================");
            Setting.rawFile.WriteLine("문항번호: " + current);
            Setting.rawFile.Write("선택순서:\t");
            initStimulus((Item)Setting.taskList[num]);

            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;

            sw.Start();
        }

        private void initStimulus(Item item)
        {
            if (item.stimulus.Contains("s.png"))
            {
                stimulus = new Word(item.stimulus, true, true);
                stimulus.Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.stimulus);
                stimulus.SetBounds((int)(Setting.SCREEN_WIDTH / 2 - 105), (int)Setting.margin.Y, 210, 280);
            }
            else if (item.stimulus.Contains(".png"))
            {
                stimulus = new Word(item.stimulus, true, true);
                stimulus.Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.stimulus);
                stimulus.SetBounds((int)(Setting.SCREEN_WIDTH / 2 - 150), (int)Setting.margin.Y, 300, 400);
            }
            else
            {
                stimulus = new Word(item.stimulus, false, true);
                stimulus.SetBounds((int)Setting.cStimulus.X, (int)Setting.cStimulus.Y, (int)Setting.sStimulus.X, (int)Setting.sStimulus.Y);
            }
            this.Controls.Add(stimulus);

            if (item.choice[0].Contains("s.png"))
            {
                choice[0] = new Word(item.choice[0], true, false);
                choice[0].Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.choice[0]);
                choice[0].SetBounds((int)(Setting.margin.X + Setting.xInterval * 5),
                                    (int)Setting.cWord[0].Y,
                                    210, 280);
            }
            else if (item.choice[0].Contains(".png"))
            {
                choice[0] = new Word(item.choice[0], true, false);
                choice[0].Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.choice[0]);
                choice[0].SetBounds((int)(Setting.margin.X + Setting.xInterval * 5),
                                    (int)Setting.cWord[0].Y,
                                    300, 400);
            }
            else
            {
                choice[0] = new Word(item.choice[0], false, false);
                choice[0].SetBounds((int)(Setting.cWord[5].X + Setting.xInterval * 4),
                                    (int)Setting.cWord[5].Y,
                                    (int)Setting.sWord.X,
                                    (int)(Setting.sWord.Y * 1.5));
            }
            choice[0].Click += new System.EventHandler(this.word_Click);
            this.Controls.Add(choice[0]);
            Setting.rawFile.Write(item.choice[0] + "\t");

            if (item.choice[1].Contains("s.png"))
            {
                choice[1] = new Word(item.choice[1], true, false);
                choice[1].Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.choice[1]);
                choice[1].SetBounds((int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 210)),
                                    (int)Setting.cWord[4].Y,
                                    210, 280);
            }
            else if (item.choice[1].Contains(".png"))
            {
                choice[1] = new Word(item.choice[1], true, false);
                choice[1].Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.choice[1]);
                choice[1].SetBounds((int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 300)),
                                    (int)Setting.cWord[4].Y,
                                    300, 400);
            }
            else
            {
                choice[1] = new Word(item.choice[1], false, false);
                choice[1].SetBounds((int)(Setting.cWord[9].X - Setting.xInterval * 4),
                                    (int)Setting.cWord[9].Y,
                                    (int)Setting.sWord.X,
                                    (int)(Setting.sWord.Y * 1.5));
            }
            choice[1].Click += new System.EventHandler(this.word_Click);
            this.Controls.Add(choice[1]);
            Setting.rawFile.Write(item.choice[1] + "\t");

            Setting.rawFile.WriteLine();
        }

        private void gazeDataStreamHandler(object sender, GazePointEventArgs e)
        {
            if (Setting.eyeOption)
            {
                Graphics gr = this.CreateGraphics();
                Brush br = new SolidBrush(Color.Red);
                gr.FillRectangle(br, (int)e.X, (int)e.Y, 5, 5);
                gr.Dispose();
            }

            for (int i = 0; i < 2; i++)
            {
                if (choice[i].isGazeHit(e.Timestamp, (int)e.X, (int)e.Y))
                {
                    Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", e.Timestamp, (int)e.X, (int)e.Y, choice[i].value));
                    return;
                }
            }

            Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}", e.Timestamp, (int)e.X, (int)e.Y));
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            lightlyFilteredGazeDataStream.Next -= gazeDataStreamHandler;
            // Setting.rawFile.WriteLine("==========================================");
        }

        private void word_Click(object sender, EventArgs e)
        {
            Console.WriteLine("==========================================");
            Setting.dataFile.WriteLine("==========================================");
            Console.WriteLine("문항번호\t" + current);
            Setting.dataFile.WriteLine("문항번호\t" + current);

            sw.Stop();
            Console.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "ms");
            Setting.dataFile.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "ms");

            Word select = (Word)sender;
            Console.WriteLine("선택단어\t" + select.value);
            Setting.dataFile.WriteLine("선택단어\t" + select.value);

            Setting.rawFile.WriteLine(Setting.rawEye);
            Setting.rawEye.Clear();

            Graphics gr = this.CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0}\t{1}", choice[i].value, choice[i].gazeTime);
                Setting.dataFile.WriteLine("{0}\t{1}", choice[i].value, choice[i].gazeTime);
            }

            // Console.WriteLine("==========================================");
            // Setting.dataFile.WriteLine("==========================================");

            this.Close();
            Setting.main.current++;
            Setting.main.showTask();
        }
    }
}