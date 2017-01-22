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
using System.Collections;

namespace ImplicitTest
{
    public partial class Main : Form
    {
        public Task1 task1;
        public Task2 task2;
        public int current;

        public Main()
        {
            InitializeComponent();
            Setting.main = this;
            setCoordinate();
            setTask();
        }

        private void setCoordinate()
        {
            Setting.SCREEN_WIDTH = SystemInformation.PrimaryMonitorSize.Width;
            Setting.SCREEN_HEIGHT = SystemInformation.PrimaryMonitorSize.Height;

            Setting.margin = new PointF(30, 30);
            Setting.sStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.margin.X * 2) / 5.0),
                (float)((Setting.SCREEN_HEIGHT - Setting.margin.Y * 2) / 10.0));
            Setting.cStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.sStimulus.X) / 2.0),
                (float)(Setting.margin.Y + Setting.sStimulus.Y));

            Setting.aWord = new PointF((float)(Setting.SCREEN_WIDTH - Setting.margin.X * 2),
                (float)((Setting.SCREEN_HEIGHT / 10.0) * 5));
            Setting.xInterval = (float)((Setting.aWord.X / 5.0) / 10.0);
            Setting.yInterval = (float)((Setting.aWord.Y / 3.0) / 10.0);
            Setting.xBuffer = (float)(((Setting.aWord.X / 5.0) - Setting.xInterval) / 8.0);
            Setting.yBuffer = (float)(((Setting.aWord.Y / 3.0) - Setting.yInterval) / 8.0);

            Setting.sWord = new PointF((float)((Setting.aWord.X / 5.0) - (Setting.xInterval * 2) - (Setting.xBuffer * 2)),
                (float)((Setting.aWord.Y / 3.0) - (Setting.yInterval * 2) - (Setting.yBuffer * 2)));

            Setting.cWord[0] = new PointF((float)(Setting.margin.X + Setting.xInterval + Setting.xBuffer),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + Setting.yInterval + Setting.yBuffer);
            Setting.cWord[1] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 3 + Setting.sWord.X),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + Setting.yInterval + Setting.yBuffer);
            Setting.cWord[2] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 5 + Setting.sWord.X * 2),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + Setting.yInterval + Setting.yBuffer);
            Setting.cWord[3] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 7 + Setting.sWord.X * 3),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + Setting.yInterval + Setting.yBuffer);
            Setting.cWord[4] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 9 + Setting.sWord.X * 4),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + Setting.yInterval + Setting.yBuffer);

            Setting.cWord[5] = new PointF((float)(Setting.margin.X + Setting.xInterval + Setting.xBuffer),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 3 + Setting.sWord.Y);
            Setting.cWord[6] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 3 + Setting.sWord.X),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 3 + Setting.sWord.Y);
            Setting.cWord[7] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 5 + Setting.sWord.X * 2),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 3 + Setting.sWord.Y);
            Setting.cWord[8] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 7 + Setting.sWord.X * 3),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 3 + Setting.sWord.Y);
            Setting.cWord[9] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 9 + Setting.sWord.X * 4),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 3 + Setting.sWord.Y);

            Setting.cWord[10] = new PointF((float)(Setting.margin.X + Setting.xInterval + Setting.xBuffer),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 5 + Setting.sWord.Y * 2);
            Setting.cWord[11] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 3 + Setting.sWord.X),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 5 + Setting.sWord.Y * 2);
            Setting.cWord[12] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 5 + Setting.sWord.X * 2),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 5 + Setting.sWord.Y * 2);
            Setting.cWord[13] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 7 + Setting.sWord.X * 3),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 5 + Setting.sWord.Y * 2);
            Setting.cWord[14] = new PointF((float)(Setting.margin.X + (Setting.xInterval + Setting.xBuffer) * 9 + Setting.sWord.X * 4),
                (float)(Setting.margin.Y + ((Setting.SCREEN_HEIGHT / 5.0) * 2)) + (Setting.yInterval + Setting.yBuffer) * 5 + Setting.sWord.Y * 2);
        }

        private void setTask()
        {
            Setting.taskList = new ArrayList();

            Item item = new Item(1, "자극1");
            item.choice = new string[15]{"단어1", "단어2", "단어3", "단어4", "단어5",
                                        "단어6", "단어7", "단어8", "단어9", "단어10",
                                        "단어11", "단어12", "단어13", "단어14", "단어15"};
            Setting.taskList.Add(item);

            item = new Item(1, "자극2");
            item.choice = new string[15]{"단어1", "단어2", "단어3", "단어4", "단어5",
                                        "단어6", "단어7", "단어8", "단어9", "단어10",
                                        "단어11", "단어12", "단어13", "단어14", "단어15"};
            Setting.taskList.Add(item);

            item = new Item(2, "자극3");
            item.choice = new string[2]{"단어1", "단어2"};
            Setting.taskList.Add(item);


            //            Setting.taskList.Add();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            current = 0;
            showTask();
        }

        public void showTask()
        {
            //task1 = new Task1();
            //task1.Show();

            if (current < Setting.taskList.Count)
            {
                Item item = (Item)Setting.taskList[current];
                if (item.type == 1)
                {
                    task1 = new Task1(current);
                    task1.Show();
                }
                else if (item.type == 2)
                {
                    task2 = new Task2(current);
                    task2.Show();
                }
            }
        }

        private void screenBtn_Click(object sender, EventArgs e)
        {
            Program.EyeXHost.LaunchDisplaySetup();
        }

        private void caliBtn_Click(object sender, EventArgs e)
        {
            Program.EyeXHost.LaunchProfileCreation();
        }
    }
}
