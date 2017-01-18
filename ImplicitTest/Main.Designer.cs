namespace ImplicitTest
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.caliBtn = new System.Windows.Forms.Button();
            this.screenBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(75, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(110, 21);
            this.textBox4.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "연락처:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "이름:";
            // 
            // caliBtn
            // 
            this.caliBtn.Location = new System.Drawing.Point(56, 138);
            this.caliBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.caliBtn.Name = "caliBtn";
            this.caliBtn.Size = new System.Drawing.Size(109, 27);
            this.caliBtn.TabIndex = 15;
            this.caliBtn.Text = "Calibration";
            this.caliBtn.UseVisualStyleBackColor = true;
            this.caliBtn.Click += new System.EventHandler(this.caliBtn_Click);
            // 
            // screenBtn
            // 
            this.screenBtn.Location = new System.Drawing.Point(56, 103);
            this.screenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.screenBtn.Name = "screenBtn";
            this.screenBtn.Size = new System.Drawing.Size(109, 27);
            this.screenBtn.TabIndex = 14;
            this.screenBtn.Text = "화면 설정";
            this.screenBtn.UseVisualStyleBackColor = true;
            this.screenBtn.Click += new System.EventHandler(this.screenBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(56, 208);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(109, 27);
            this.startBtn.TabIndex = 13;
            this.startBtn.Text = "시작";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.Location = new System.Drawing.Point(56, 173);
            this.settingBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(109, 27);
            this.settingBtn.TabIndex = 16;
            this.settingBtn.Text = "실험 환경 설정";
            this.settingBtn.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 261);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.caliBtn);
            this.Controls.Add(this.screenBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IAT 2017";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button caliBtn;
        private System.Windows.Forms.Button screenBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button settingBtn;
    }
}

