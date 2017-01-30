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
            taskNum.Text = "문항\t" + (current);
            Item task = (Item)Setting.taskList[num];

            Setting.rawFile.WriteLine("==========================================");
            Setting.rawFile.WriteLine("문항번호:\t" + current);
            Setting.rawFile.WriteLine("문항유형:\t" + task.type);
            Setting.rawFile.WriteLine("제시자극:\t" + task.stimulus);
            Setting.rawFile.WriteLine("선택순서:");
            initStimulus(task);

            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;

            sw.Start();
        }

        private void initStimulus(Item item)
        {
            //item.shuffle();
            if (!Setting.pictureType) item.reverse();

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
            if (item.choice[0].Contains("s.png"))
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[0].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.margin.X + Setting.xInterval * 5) - Setting.xBuffer,
                    (int)Setting.cWord[0].Y - Setting.yBuffer,
                    (int)(Setting.margin.X + Setting.xInterval * 5) + 210 + Setting.xBuffer,
                    (int)Setting.cWord[0].Y + 280 + Setting.yBuffer);
            }
            else if (item.choice[0].Contains(".png"))
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[0].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.margin.X + Setting.xInterval * 5) - Setting.xBuffer,
                    (int)Setting.cWord[0].Y - Setting.yBuffer,
                    (int)(Setting.margin.X + Setting.xInterval * 5) + 300 + Setting.xBuffer,
                    (int)Setting.cWord[0].Y + 400 + Setting.yBuffer);
            }
            else
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[0].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.cWord[5].X + Setting.xInterval * 4) - Setting.xBuffer,
                    (int)Setting.cWord[5].Y,
                    (int)(Setting.cWord[5].X + Setting.xInterval * 4) + (int)Setting.sWord.X + Setting.xBuffer,
                    (int)Setting.cWord[5].Y + (int)(Setting.sWord.Y * 1.5) + Setting.yBuffer);
            }

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
            if (item.choice[1].Contains("s.png"))
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[1].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 210)) - Setting.xBuffer,
                    (int)Setting.cWord[4].Y - Setting.yBuffer,
                    (int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 210)) + 210 + Setting.xBuffer,
                    (int)Setting.cWord[4].Y + 280 + Setting.yBuffer);
            }
            else if (item.choice[1].Contains(".png"))
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[1].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 300)) - Setting.xBuffer,
                    (int)Setting.cWord[4].Y - Setting.yBuffer,
                    (int)(Setting.SCREEN_WIDTH - (Setting.margin.X + Setting.xInterval * 5 + 300)) + 300 + Setting.xBuffer,
                    (int)Setting.cWord[4].Y + 400 + Setting.yBuffer);
            }
            else
            {
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[1].Replace("\r\n", " ").Replace(",", " +") + "\t",
                    (int)(Setting.cWord[9].X - Setting.xInterval * 4) - Setting.xBuffer,
                    (int)Setting.cWord[9].Y,
                    (int)(Setting.cWord[9].X - Setting.xInterval * 4) + (int)Setting.sWord.X + Setting.xBuffer,
                    (int)Setting.cWord[9].Y + (int)(Setting.sWord.Y * 1.5) + Setting.yBuffer);
            }
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
            Console.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "\t ms");
            Setting.dataFile.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "\t ms");
            Setting.rawFile.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "\t ms");

            Word select = (Word)sender;
            Console.WriteLine("선택단어\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));
            Setting.dataFile.WriteLine("선택단어\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));
            Setting.rawFile.WriteLine("선택단어\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));

            Setting.rawFile.WriteLine(Setting.rawEye);
            Setting.rawEye.Clear();

            Graphics gr = this.CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();

            for (int i = 0; i < 2; i++)
            {
                string word = choice[i].value.Replace("\r\n", " ").Replace(",", " +");

                Console.WriteLine("{0}\t{1}", word, (int)choice[i].gazeTime);
                Setting.dataFile.WriteLine("{0}\t{1}", word, (int)choice[i].gazeTime);
                Setting.csvFile.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}",
                    Setting.ID, current, sw.ElapsedMilliseconds.ToString(), select.value.Replace("\r\n", " ").Replace(",", " +"), word, (int)choice[i].gazeTime));
            }

            // Console.WriteLine("==========================================");
            // Setting.dataFile.WriteLine("==========================================");

            this.Close();
            Setting.main.current++;
            Setting.main.showTask();
        }
    }
}