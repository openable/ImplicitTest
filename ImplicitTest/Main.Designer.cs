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
            System.Windows.Forms.RadioButton eyeOption2;
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.caliBtn = new System.Windows.Forms.Button();
            this.screenBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.eyeGroup = new System.Windows.Forms.GroupBox();
            this.eyeOption1 = new System.Windows.Forms.RadioButton();
            this.pictureType1 = new System.Windows.Forms.RadioButton();
            this.fontNum = new System.Windows.Forms.TextBox();
            this.startNum = new System.Windows.Forms.TextBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.pictureGroup = new System.Windows.Forms.GroupBox();
            this.pictureType2 = new System.Windows.Forms.RadioButton();
            eyeOption2 = new System.Windows.Forms.RadioButton();
            this.eyeGroup.SuspendLayout();
            this.pictureGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // eyeOption2
            // 
            eyeOption2.AutoSize = true;
            eyeOption2.Checked = true;
            eyeOption2.Location = new System.Drawing.Point(135, 15);
            eyeOption2.Name = "eyeOption2";
            eyeOption2.Size = new System.Drawing.Size(59, 16);
            eyeOption2.TabIndex = 7;
            eyeOption2.TabStop = true;
            eyeOption2.Text = "아니오";
            eyeOption2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            eyeOption2.UseVisualStyleBackColor = true;
            eyeOption2.CheckedChanged += new System.EventHandler(this.eyeOption2_CheckedChanged);
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(75, 47);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(110, 21);
            this.phoneBox.TabIndex = 2;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(75, 17);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(110, 21);
            this.nameBox.TabIndex = 1;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(23, 50);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(45, 12);
            this.phoneLabel.TabIndex = 10;
            this.phoneLabel.Text = "연락처:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(48, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(20, 12);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "ID:";
            // 
            // caliBtn
            // 
            this.caliBtn.Location = new System.Drawing.Point(56, 120);
            this.caliBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.caliBtn.Name = "caliBtn";
            this.caliBtn.Size = new System.Drawing.Size(109, 27);
            this.caliBtn.TabIndex = 3;
            this.caliBtn.Text = "Calibration";
            this.caliBtn.UseVisualStyleBackColor = true;
            this.caliBtn.Click += new System.EventHandler(this.caliBtn_Click);
            // 
            // screenBtn
            // 
            this.screenBtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.screenBtn.Location = new System.Drawing.Point(56, 80);
            this.screenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.screenBtn.Name = "screenBtn";
            this.screenBtn.Size = new System.Drawing.Size(109, 27);
            this.screenBtn.TabIndex = 11;
            this.screenBtn.Text = "화면 설정";
            this.screenBtn.UseVisualStyleBackColor = true;
            this.screenBtn.Click += new System.EventHandler(this.screenBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(56, 320);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(109, 27);
            this.startBtn.TabIndex = 8;
            this.startBtn.Text = "시작";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // eyeGroup
            // 
            this.eyeGroup.Controls.Add(eyeOption2);
            this.eyeGroup.Controls.Add(this.eyeOption1);
            this.eyeGroup.Location = new System.Drawing.Point(12, 270);
            this.eyeGroup.Name = "eyeGroup";
            this.eyeGroup.Size = new System.Drawing.Size(200, 40);
            this.eyeGroup.TabIndex = 12;
            this.eyeGroup.TabStop = false;
            this.eyeGroup.Text = "시선 표시";
            // 
            // eyeOption1
            // 
            this.eyeOption1.AutoSize = true;
            this.eyeOption1.Location = new System.Drawing.Point(34, 15);
            this.eyeOption1.Name = "eyeOption1";
            this.eyeOption1.Size = new System.Drawing.Size(35, 16);
            this.eyeOption1.TabIndex = 6;
            this.eyeOption1.Text = "예";
            this.eyeOption1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eyeOption1.UseVisualStyleBackColor = true;
            this.eyeOption1.CheckedChanged += new System.EventHandler(this.eyeOption1_CheckedChanged);
            // 
            // pictureType1
            // 
            this.pictureType1.AutoSize = true;
            this.pictureType1.Checked = true;
            this.pictureType1.Location = new System.Drawing.Point(38, 15);
            this.pictureType1.Name = "pictureType1";
            this.pictureType1.Size = new System.Drawing.Size(31, 16);
            this.pictureType1.TabIndex = 16;
            this.pictureType1.TabStop = true;
            this.pictureType1.Text = "A";
            this.pictureType1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pictureType1.UseVisualStyleBackColor = true;
            this.pictureType1.CheckedChanged += new System.EventHandler(this.pictureType1_CheckedChanged);
            // 
            // fontNum
            // 
            this.fontNum.Location = new System.Drawing.Point(85, 187);
            this.fontNum.MaxLength = 4;
            this.fontNum.Name = "fontNum";
            this.fontNum.Size = new System.Drawing.Size(100, 21);
            this.fontNum.TabIndex = 5;
            this.fontNum.Text = "20";
            // 
            // startNum
            // 
            this.startNum.Location = new System.Drawing.Point(85, 157);
            this.startNum.MaxLength = 4;
            this.startNum.Name = "startNum";
            this.startNum.Size = new System.Drawing.Size(100, 21);
            this.startNum.TabIndex = 4;
            this.startNum.Text = "1";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(22, 190);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(61, 12);
            this.fontLabel.TabIndex = 14;
            this.fontLabel.Text = "글씨 크기:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(22, 160);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(61, 12);
            this.startLabel.TabIndex = 13;
            this.startLabel.Text = "시작 위치:";
            // 
            // pictureGroup
            // 
            this.pictureGroup.Controls.Add(this.pictureType2);
            this.pictureGroup.Controls.Add(this.pictureType1);
            this.pictureGroup.Location = new System.Drawing.Point(12, 220);
            this.pictureGroup.Name = "pictureGroup";
            this.pictureGroup.Size = new System.Drawing.Size(200, 40);
            this.pictureGroup.TabIndex = 13;
            this.pictureGroup.TabStop = false;
            this.pictureGroup.Text = "사진 유형";
            // 
            // pictureType2
            // 
            this.pictureType2.AutoSize = true;
            this.pictureType2.Location = new System.Drawing.Point(135, 15);
            this.pictureType2.Name = "pictureType2";
            this.pictureType2.Size = new System.Drawing.Size(31, 16);
            this.pictureType2.TabIndex = 17;
            this.pictureType2.TabStop = true;
            this.pictureType2.Text = "B";
            this.pictureType2.UseVisualStyleBackColor = true;
            this.pictureType2.CheckedChanged += new System.EventHandler(this.pictureType2_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 361);
            this.Controls.Add(this.pictureGroup);
            this.Controls.Add(this.eyeGroup);
            this.Controls.Add(this.caliBtn);
            this.Controls.Add(this.screenBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.fontNum);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.startNum);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.startLabel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WAT";
            this.eyeGroup.ResumeLayout(false);
            this.eyeGroup.PerformLayout();
            this.pictureGroup.ResumeLayout(false);
            this.pictureGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button caliBtn;
        private System.Windows.Forms.Button screenBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.GroupBox eyeGroup;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.RadioButton eyeOption1;
        private System.Windows.Forms.TextBox fontNum;
        private System.Windows.Forms.TextBox startNum;
        private System.Windows.Forms.RadioButton pictureType1;
        private System.Windows.Forms.GroupBox pictureGroup;
        private System.Windows.Forms.RadioButton pictureType2;
    }
}

