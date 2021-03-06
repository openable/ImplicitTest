﻿using System;
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
    public partial class Task1 : Form
    {
        private GazePointDataStream lightlyFilteredGazeDataStream =
            Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
        private int current;
        private Word stimulus;
        private Word[] words = new Word[15];
        Stopwatch sw = new Stopwatch();

        private bool outSequece = false;
        private double outGaze = 0.0;
        private double outStart = 0.0;
        Stopwatch osw = new Stopwatch();

        public Task1(int num)
        {
            InitializeComponent();

            // 전체화면 만들기
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            current = num + 1;
            taskNum.Text = "문항:\t" + (current);
            Item task = (Item)Setting.taskList[num];

            Setting.rawFile.WriteLine("==========================================");
            Setting.rawFile.WriteLine("문항번호:\t" + current);
            Setting.rawFile.WriteLine("문항유형:\t" + task.type);

            initStimulus(task);

            lightlyFilteredGazeDataStream.Next += gazeDataStreamHandler;
            Program.EyeXHost.GazeTrackingChanged += EyeXHost_GazeTrackingChanged;

            sw.Start();
        }

        private void initStimulus(Item item)
        {
            item.shuffle();

            if (item.stimulus.Contains("s.png"))
            {
                stimulus = new Word(item.stimulus, true, true);
                stimulus.Image = Image.FromFile(Application.StartupPath + "\\model\\" + item.stimulus);
                stimulus.SetBounds((int)(Setting.SCREEN_WIDTH/2-105), (int)Setting.margin.Y, 210, 280);
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
            Setting.rawFile.WriteLine("제시자극:\t" + item.stimulus.Replace("\r\n", " ").Replace(",", " +") +
                "\t" + (stimulus.Location.X - Setting.xBuffer) + "\t" + (stimulus.Location.Y - Setting.yBuffer) +
                "\t" + (stimulus.Size.Width + (2 * Setting.xBuffer)) + "\t" + (stimulus.Size.Height + (2 * Setting.yBuffer)));

            Setting.rawFile.WriteLine("선택순서:");
            for (int i = 0; i < 15; i++)
            {
                words[i] = new Word(item.choice[i], false, false);
                words[i].SetBounds((int)Setting.cWord[i].X, (int)Setting.cWord[i].Y, (int)Setting.sWord.X, (int)Setting.sWord.Y);
                words[i].Click += new System.EventHandler(this.word_Click);
                this.Controls.Add(words[i]);
                Setting.rawFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    item.choice[i].Replace("\r\n", " ").Replace(",", " +"),
                    (int)Setting.cWord[i].X - Setting.xBuffer,
                    (int)Setting.cWord[i].Y - Setting.yBuffer,
                    ((int)Setting.sWord.X + (2 * Setting.xBuffer)),
                    ((int)Setting.sWord.Y + (2 * Setting.yBuffer)));
            }
        }

        private void gazeDataStreamHandler(object sender, GazePointEventArgs e)
        {
            //Console.WriteLine(string.Format("{0}\t{1}\t{2}", e.Timestamp, (int)e.X, (int)e.Y));

            if (Setting.eyeOption)
            {
                Graphics gr = this.CreateGraphics();
                Brush br = new SolidBrush(Color.Red);
                gr.FillRectangle(br, (int)e.X, (int)e.Y, 5, 5);
                gr.Dispose();
            }

            if (e.X < 0 || e.X > Setting.SCREEN_WIDTH || e.Y < 0 || e.Y > Setting.SCREEN_HEIGHT)
            {
                Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", e.Timestamp, (int)e.X, (int)e.Y, "-"));

                if (!outSequece)
                {
                    outSequece = true;
                    outStart = e.Timestamp;
                }
                else
                {
                    outGaze = outGaze + (e.Timestamp - outStart);
                    outStart = e.Timestamp;
                }

                return;
            }
            else
            {
                outSequece = false;
            }

            if (stimulus.isGazeHit(e.Timestamp, (int)e.X, (int)e.Y))
            {
                Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}",
                    e.Timestamp, (int)e.X, (int)e.Y, stimulus.value.Replace("\r\n", " ").Replace(",", " +")));
                return;
            }

            for (int i = 0; i < 15; i++)
            {
                if (words[i].isGazeHit(e.Timestamp, (int)e.X, (int)e.Y))
                {
                    Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}",
                        e.Timestamp, (int)e.X, (int)e.Y, words[i].value.Replace("\r\n", " ").Replace(",", " +")));
                    return;
                }
            }

            Setting.rawEye.AppendLine(string.Format("{0}\t{1}\t{2}", e.Timestamp, (int)e.X, (int)e.Y));
        }

        private void EyeXHost_GazeTrackingChanged(object sender, EngineStateValue<GazeTracking> e)
        {
            if (Created)
            {
                BeginInvoke(new Action(() =>
                {
                    if (e.IsValid && e.Value == GazeTracking.GazeTracked)
                    {
                        //outSequece = false;
                        osw.Stop();
                        outGaze = outGaze + osw.ElapsedMilliseconds;
                        Setting.rawEye.AppendLine("[Out End]" + "\t" + osw.ElapsedMilliseconds);
                        osw.Reset();
                    }
                    else
                    {
                        //outSequece = true;
                        osw.Start();
                        Setting.rawEye.AppendLine("[Out Start]");
                    }
                }));
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            lightlyFilteredGazeDataStream.Next -= gazeDataStreamHandler;
            Program.EyeXHost.GazeTrackingChanged -= EyeXHost_GazeTrackingChanged;
            // Setting.rawFile.WriteLine("==========================================");
        }

        private void word_Click(object sender, EventArgs e)
        {
            sw.Stop();

            Console.WriteLine("==========================================");
            Setting.dataFile.WriteLine("==========================================");
            Console.WriteLine("문항번호\t" + current);
            Setting.dataFile.WriteLine("문항번호\t" + current);
            
            Console.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "\t ms");
            Setting.dataFile.WriteLine("응답시간\t" + sw.ElapsedMilliseconds.ToString() + "\t ms");
            Setting.rawFile.WriteLine("응답시간:\t" + sw.ElapsedMilliseconds.ToString());

            Word select = (Word)sender;
            Console.WriteLine("선택단어\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));
            Setting.dataFile.WriteLine("선택단어\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));
            Setting.rawFile.WriteLine("선택단어:\t" + select.value.Replace("\r\n", " ").Replace(",", " +"));

            Graphics gr = this.CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();

            double totalGaze = 0.0;
            Setting.rawFile.WriteLine("응시시간:");
            Setting.rawFile.WriteLine(stimulus.value.Replace("\r\n", " ").Replace(",", " +") + "\t" + stimulus.gazeTime);
            totalGaze = totalGaze + stimulus.gazeTime;

            for (int i = 0; i < 15; i++)
            {
                string word = words[i].value.Replace("\r\n", " ").Replace(",", " +");

                Console.WriteLine("{0}\t{1}", word, (int)words[i].gazeTime);
                Setting.dataFile.WriteLine("{0}\t{1}", word, (int)words[i].gazeTime);
                Setting.csvFile.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}",
                    Setting.ID, current, stimulus.value.Replace("\r\n", " ").Replace(",", " +"),
                    sw.ElapsedMilliseconds.ToString(), select.value.Replace("\r\n", " ").Replace(",", " +"),
                    word, (int)words[i].gazeTime));

                Setting.rawFile.WriteLine(words[i].value.Replace("\r\n", " ").Replace(",", " +") + "\t" + words[i].gazeTime);
                totalGaze = totalGaze + words[i].gazeTime;
            }
            
            Setting.rawFile.WriteLine("총 응시시간:\t" + totalGaze + "\t" + (int)((totalGaze / sw.ElapsedMilliseconds) * 100));
            Setting.rawFile.WriteLine("총 이탈시간:\t" + outGaze + "\t" + (int)((outGaze / sw.ElapsedMilliseconds) * 100));
            Setting.rawFile.WriteLine("총 이동비중:\t" + (100 - (int)((totalGaze / sw.ElapsedMilliseconds) * 100) - (int)((outGaze / sw.ElapsedMilliseconds) * 100)));

            Setting.rawFile.WriteLine(Setting.rawEye);
            Setting.rawEye.Clear();

            // Console.WriteLine("==========================================");
            // Setting.dataFile.WriteLine("==========================================");

            this.Close();
            Setting.main.current++;
            Setting.main.showTask();
        }
    }
}