﻿using System;
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
        public Back back;
        public Back guide;
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
            Setting.sStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.margin.X * 2) / 4.0),
                (float)((Setting.SCREEN_HEIGHT - Setting.margin.Y * 2) / 8.0));
            Setting.cStimulus = new PointF((float)((Setting.SCREEN_WIDTH - Setting.sStimulus.X) / 2.0),
                (float)(Setting.margin.Y + (Setting.sStimulus.Y / 2)));

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

            Random r = new Random();
            int num = r.Next(0, 2);

            if (num == 0)
                pictureType1.Checked = true;
            else
                pictureType2.Checked = true;
        }

        private void setTask()
        {
            Setting.taskList = new ArrayList();
            Item item = new Item();

            item = new Item();
            item.content = "두 번째 실험입니다.\r\n제시된 사진을 보고 가장 연상되는 단어 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            //연습 1번
            item = new Item(1, "토끼s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "무섭다",
                                        "다채롭다", "놀랍다", "자극적이다", "징그럽다", "매스껍다",
                                        "화려하다", "혐오스럽다", "즐겁다", "단조롭다", "심심하다"};
            Setting.taskList.Add(item);

            //연습 2번
            item = new Item(1, "호랑이s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "무섭다",
                                        "다채롭다", "놀랍다", "자극적이다", "징그럽다", "매스껍다",
                                        "화려하다", "혐오스럽다", "즐겁다", "단조롭다", "심심하다"};
            Setting.taskList.Add(item);

            //연습 3번
            item = new Item(1, "뱀s.png");
            item.choice = new string[15]{"예쁘다", "귀엽다", "독특하다", "훈훈하다", "무섭다",
                                        "다채롭다", "놀랍다", "자극적이다", "징그럽다", "매스껍다",
                                        "화려하다", "혐오스럽다", "즐겁다", "단조롭다", "심심하다"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "문재인 후보와 가장 연관된 단어 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            //문 연상단어 1번
            item = new Item(1, "문재인s.png");
            item.choice = new string[15]{"공감", "공정", "다르다", "뭉클하다", "카리스마 부족",
                                        "빨갱이", "개헌", "보안법 철폐", "새로운", "친북",
                                        "비리", "부자", "광주", "단단한\r\n지지기반", "SNS"};
            Setting.taskList.Add(item);

            //문 연상단어 2번
            item = new Item(1, "문재인s.png");
            item.choice = new string[15]{"온건", "진정성", "친서민", "패권주의", "청렴",
                                        "준비된", "소통", "대세론", "적폐청산", "개혁",
                                        "사드 재검토", "워킹맘 논란", "노인 폄하 논란", "노무현", "특전사"};
            Setting.taskList.Add(item);

            //문 연상단어 3번
            item = new Item(1, "문재인s.png");
            item.choice = new string[15]{"포퓰리즘", "사탕발림 공약", "검증된", "일자리 창출", "만18세 선거권",
                                        "종북", "국가안보 위협", "금괴 루머", "호남", "대담집",
                                        "위안부 재협의", "뻔한 정치인", "우유부단", "구태의연", "말바꾸기"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "안철수 후보와 가장 연관된 단어 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            //안 연상단어 1번
            item = new Item(1, "안철수s.png");
            item.choice = new string[15]{"강단있는", "겸손한", "공정한", "샌님같은", "혁신적인",
                                        "거짓말", "완벽주의", "안랩", "중도 보수", "공정 성장",
                                        "양보", "사드", "새누리당의\r\n이중대", "호남", "융합"};
            Setting.taskList.Add(item);

            //안 연상단어 2번
            item = new Item(1, "안철수s.png");
            item.choice = new string[15]{"카리스마 부족", "희망", "정직하다", "정치 경험 부족", "소심한",
                                        "포용하는", "모호한 정체성", "밀리다", "외골수", "개혁",
                                        "과학기술", "5대 절벽", "간철수", "반문재인", "기업가 정신"};
            Setting.taskList.Add(item);

            //안 연상단어 3번
            item = new Item(1, "안철수s.png");
            item.choice = new string[15]{"무능하다", "지적인", "밋밋하다", "선견지명", "소신있는",
                                        "신뢰", "신중한", "온화함", "독자노선", "새정치",
                                        "정치적 왕따", "제4차산업혁명", "강철수", "낮은 지지율", "사회환원"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "차기 대통령이 갖추어야 할 가장 중요한 덕목 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 차기 대통령 덕목
            item = new Item(1, "차기 대통령 덕목");
            item.choice = new string[15]{"깨끗한", "국민을\r\n생각하는", "소통하는", "소신있는", "도덕적인",
                                        "강력한 리더십", "정치, 행정경험", "판단력", "비전", "진실성",
                                        "책임감", "통찰력", "성실성", "추진력", "언행일치"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "두 후보 중 어느 후보가 제시된 덕목을 더 갖추었다고 생각하십니까?\r\n해당 사진을 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 덕목의 후보별 연관 비중
            string[] list1 = new string[15]{"깨끗한", "국민을 생각하는", "소통하는", "소신있는", "도덕적인",
                                        "강력한 리더십", "정치, 행정경험", "판단력", "비전", "진실성",
                                        "책임감", "통찰력", "성실성", "추진력", "언행일치"};
            for (int i = 0; i < 15; i++)
            {
                item = new Item(2, list1[i]);
                item.choice = new string[2] { "문재인.png", "안철수.png" };
                Setting.taskList.Add(item);
            }

            item = new Item();
            item.content = "문재인 후보가 어떤 덕목을 갖추면 투표하시겠습니까?\r\n가장 필요한 덕목 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 문에게 필요한 덕목
            item = new Item(1, "문재인s.png");
            item.choice = new string[15]{"깨끗한", "국민을\r\n생각하는", "소통하는", "소신있는", "도덕적인",
                                        "강력한 리더십", "정치, 행정경험", "판단력", "비전", "진실성",
                                        "책임감", "통찰력", "성실성", "추진력", "언행일치"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "안철수 후보가 어떤 덕목을 갖추면 투표하시겠습니까?\r\n가장 필요한 덕목 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 안에게 필요한 덕목
            item = new Item(1, "안철수s.png");
            item.choice = new string[15]{"깨끗한", "국민을\r\n생각하는", "소통하는", "소신있는", "도덕적인",
                                        "강력한 리더십", "정치, 행정경험", "판단력", "비전", "진실성",
                                        "책임감", "통찰력", "성실성", "추진력", "언행일치"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "차기 정부가 추진해야 할 가장 중요한 정책 하나를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 차기 정부 중점 정책
            item = new Item(1, "차기 정부 중점 정책");
            item.choice = new string[15]{"일자리 창출", "저출산,\r\n고령화 해소", "미세먼지,\r\n대기오염 해결", "개헌", "만18세 선거권",
                                        "재벌개혁,\r\n정경유착 근절", "사드 갈등 해결", "위안부 갈등\r\n해결", "북핵 문제 해결", "부정부패 척결",
                                        "물가 안정", "병역 개선", "주택 수급\r\n불균형 개선", "입시위주 교육개혁", "4차산업 육성"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "두 후보 중 어느 후보가 제시된 정책을 더 잘 추진할 것이라고\r\n생각하십니까?\r\n해당 사진을 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 정책 후보별 연관 비중
            string[] list2 = new string[15]{"일자리 창출", "저출산,\r\n고령화 해소", "미세먼지,\r\n대기오염 해결", "개헌", "만18세 선거권",
                                        "재벌개혁,\r\n정경유착 근절", "사드 갈등 해결", "위안부 갈등\r\n해결", "북핵 문제 해결", "부정부패 척결",
                                        "물가 안정", "병역 개선", "주택 수급\r\n불균형 개선", "입시위주 교육개혁", "4차산업 육성"};
            for (int i = 0; i < 15; i++)
            {
                item = new Item(2, list2[i]);
                item.choice = new string[2] { "문재인.png", "안철수.png" };
                Setting.taskList.Add(item);
            }

            item = new Item();
            item.content = "문재인 후보가 어떤 정책을 추진하면 투표하시겠습니까?\r\n가장 필요한 정책 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 문에게 필요한 정책
            item = new Item(1, "문재인s.png");
            item.choice = new string[15]{"일자리 창출", "저출산,\r\n고령화 해소", "미세먼지,\r\n대기오염 해결", "개헌", "만18세 선거권",
                                        "재벌개혁,\r\n정경유착 근절", "사드 갈등 해결", "위안부 갈등\r\n해결", "북핵 문제 해결", "부정부패 척결",
                                        "물가 안정", "병역 개선", "주택 수급\r\n불균형 개선", "입시위주 교육개혁", "4차산업 육성"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "안철수 후보가 어떤 정책을 추진하면 투표하시겠습니까?\r\n가장 필요한 정책 한 개를 클릭해 주세요.";
            item.msg = "준비 되셨으면 [시작] 버튼을 클릭해 주세요.";
            Setting.taskList.Add(item);

            // 안에게 필요한 정책
            item = new Item(1, "안철수s.png");
            item.choice = new string[15]{"일자리 창출", "저출산,\r\n고령화 해소", "미세먼지,\r\n대기오염 해결", "개헌", "만18세 선거권",
                                        "재벌개혁,\r\n정경유착 근절", "사드 갈등 해결", "위안부 갈등\r\n해결", "북핵 문제 해결", "부정부패 척결",
                                        "물가 안정", "병역 개선", "주택 수급\r\n불균형 개선", "입시위주 교육개혁", "4차산업 육성"};
            Setting.taskList.Add(item);

            item = new Item();
            item.content = "모든 실험이 종료되었습니다.\r\n감사합니다.";
            item.msg = "";
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
            Setting.ID = nameBox.Text;
            Encoding encode = System.Text.Encoding.GetEncoding("ks_c_5601-1987");

            if (startNum.Text.Equals("1"))
            {
                Setting.dataFile = new StreamWriter(path + "\\" + nameBox.Text + "-data.txt", true, encode);
                Setting.csvFile = new StreamWriter(path + "\\" + nameBox.Text + "-data.csv", true, encode);
                Setting.rawFile = new StreamWriter(path + "\\" + nameBox.Text + "-raw.txt", true, encode);
            }
            else
            {
                Setting.dataFile = new StreamWriter(path + "\\" + nameBox.Text + "-" + startNum.Text + "-data.txt", true, encode);
                Setting.csvFile = new StreamWriter(path + "\\" + nameBox.Text + "-" + startNum.Text + "-data.csv", true, encode);
                Setting.rawFile = new StreamWriter(path + "\\" + nameBox.Text + "-" + startNum.Text + "-raw.txt", true, encode);
            }
            Setting.csvFile.WriteLine("피험자 ID,문항번호,제시자극,응답시간,선택단어,단어,Eye Track time (ms)");
            Setting.rawEye = new StringBuilder();

            this.Hide();
            Console.WriteLine("[실험 시작]\t" + nameBox.Text + "\t" + phoneBox.Text + "\t" + Setting.SCREEN_WIDTH + "\t" + Setting.SCREEN_HEIGHT);
            Setting.dataFile.WriteLine("[실험 시작]\t" + nameBox.Text + "\t" + phoneBox.Text + "\t" + Setting.SCREEN_WIDTH + "\t" + Setting.SCREEN_HEIGHT);
            Setting.rawFile.WriteLine("[실험 시작]\t" + nameBox.Text + "\t" + phoneBox.Text + "\t" + Setting.SCREEN_WIDTH + "\t" + Setting.SCREEN_HEIGHT);
            // 시작하는 위치 설정 변수 current, 값 바꾸면 중간 부터 시작
            current = Convert.ToInt16(startNum.Text) - 1;
            Setting.fontSize = Convert.ToInt16(fontNum.Text);
            back = new Back();
            back.Show();
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
                else
                {
                    guide = new Back(current);
                    guide.Show();
                }
            }
            else
            {
                Console.WriteLine("[실험 종료]");
                Setting.dataFile.WriteLine("[실험 종료]");
                Setting.rawFile.WriteLine("[실험 종료]");
                Setting.dataFile.Close();
                Setting.csvFile.Close();
                Setting.rawFile.Close();
                back.Close();
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

        private void pictureType1_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureType1.Checked)
                Setting.pictureType = true;
            else
                Setting.pictureType = false;
        }

        private void pictureType2_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureType2.Checked)
                Setting.pictureType = false;
            else
                Setting.pictureType = true;
        }
    }
}
