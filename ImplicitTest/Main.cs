using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            Item item = new Item();

            //연습 3개
            item = new Item(1, "토끼s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "싫다",
                                        "다채롭다", "놀랍다", "자극적이다", "새롭다", "매스껍다",
                                        "신선하다", "혐오스럽다", "즐겁다", "단조롭다", "좋다"};
            Setting.taskList.Add(item);

            item = new Item(1, "호랑이s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "싫다",
                                        "다채롭다", "놀랍다", "자극적이다", "새롭다", "매스껍다",
                                        "신선하다", "혐오스럽다", "즐겁다", "단조롭다", "좋다"};
            Setting.taskList.Add(item);

            item = new Item(1, "뱀s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "싫다",
                                        "다채롭다", "놀랍다", "자극적이다", "새롭다", "매스껍다",
                                        "신선하다", "혐오스럽다", "즐겁다", "단조롭다", "좋다"};
            Setting.taskList.Add(item);

            
            item = new Item(1, "문재인.png");
            item.choice = new string[15]{"공감", "공정", "다르다", "뭉클하다", "카리스마 부족",
                                        "빨갱이", "개헌", "진정성", "친서민", "패권주의",
                                        "청렴", "준비된", "소통", "대세론", "포퓰리즘"};
            Setting.taskList.Add(item);

            item = new Item(1, "반기문");
            item.choice = new string[15]{"유리멘탈", "기회주의", "눈치", "무능", "노무현 배신",
                                        "엘리트", "우려 발언", "유력", "최악", "서민 친화 코스프레",
                                        "미검증", "친근", "가식", "무리수", "광폭행보"};
            Setting.taskList.Add(item);

            item = new Item(1, "차기 대통령 덕목");
            item.choice = new string[15]{"깨끗한", "국민을 생각하는", "소통하는", "똑똑한", "소신있는",
                                        "일자리 창출 대통령", "정치를 잘하는", "도덕적인", "진보적인", "강력한 리더십",
                                        "경제 활성화 능력", "정치, 행정경험", "외교/안보/통일 능력", "행정 경험", "판단력"};
            Setting.taskList.Add(item);

            item = new Item(2, "깨끗한");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);

            item = new Item(2, "소통하는");
            item.choice = new string[2] { "반기문", "문재인" };
            Setting.taskList.Add(item);

            item = new Item(2, "똑똑한");
            item.choice = new string[2] { "문재인", "문재인" };
            Setting.taskList.Add(item);

            item = new Item(2, "정치, 행정경험");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);

            item = new Item(2, "도덕적인");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);

            item = new Item(1, "차기 정부 중점 정책");
            item.choice = new string[15]{"일자리 창출", "저출산, 고령화 해소", "양극화 해소", "신성장동력 육성", "기업투자 확대",
                                        "외교역량 강화", "사드 갈등 해결", "위안부 갈등 해결", "북핵 문제 해결", "부정부패 척결",
                                        "물가 안정", "정경유착 근절", "주택 수급 불균형 개선", "국정 교과서 폐지", "세월호 진상 조사"};
            Setting.taskList.Add(item);

            item = new Item(2, "저출산, 고령화 해소");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);

            item = new Item(2, "사드 갈등 해결");
            item.choice = new string[2] { "반기문", "문재인" };
            Setting.taskList.Add(item);

            item = new Item(2, "정경유착 근절");
            item.choice = new string[2] { "문재인", "문재인" };
            Setting.taskList.Add(item);

            item = new Item(2, "물가 안정");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);

            item = new Item(2, "일자리 창출");
            item.choice = new string[2] { "문재인", "반기문" };
            Setting.taskList.Add(item);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Equals(""))
            {
                MessageBox.Show("ID를 입력해 주세요.", "오류", MessageBoxButtons.OK);
                nameBox.Focus();
                return;
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (startNum.Text.Equals("1"))
            {
                Setting.dataFile = new StreamWriter(path + "\\" + nameBox.Text + "-data.txt", true);
                Setting.rawFile = new StreamWriter(path + "\\" + nameBox.Text + "-raw.txt", true);
            }
            else
            {
                Setting.dataFile = new StreamWriter(path + "\\" + nameBox.Text + "-" + startNum.Text + "-data.txt", true);
                Setting.rawFile = new StreamWriter(path + "\\" + nameBox.Text + "-" + startNum.Text + "-raw.txt", true);
            }

            this.Hide();
            Console.WriteLine("[실험 시작]\t" + nameBox.Text + " - " + phoneBox.Text);
            Setting.dataFile.WriteLine("[실험 시작]\t" + nameBox.Text + " - " + phoneBox.Text);
            Setting.rawFile.WriteLine("[실험 시작]\t" + nameBox.Text + " - " + phoneBox.Text);
            // 시작하는 위치 설정 변수 current, 값 바꾸면 중간 부터 시작
            current = Convert.ToInt16(startNum.Text) - 1;
            Setting.fontSize = Convert.ToInt16(fontNum.Text);
            showTask();
        }

        public void showTask()
        {
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
            else
            {
                Console.WriteLine("[실험 종료]");
                Setting.dataFile.WriteLine("[실험 종료]");
                Setting.rawFile.WriteLine("[실험 종료]");
                Setting.dataFile.Close();
                Setting.rawFile.Close();
                this.Close();
                // Application.ExitThread();
                // Process.GetCurrentProcess().Kill();
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

        private void eyeOption1_CheckedChanged(object sender, EventArgs e)
        {
            Setting.eyeOption = true;
        }

        private void eyeOption2_CheckedChanged(object sender, EventArgs e)
        {
            Setting.eyeOption = false;
        }
    }
}
