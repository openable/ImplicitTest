namespace ImplicitTest
{
    partial class Back
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.content = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.AutoSize = true;
            this.content.Font = new System.Drawing.Font("Malgun Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.content.ForeColor = System.Drawing.Color.Yellow;
            this.content.Location = new System.Drawing.Point(63, 71);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(52, 28);
            this.content.TabIndex = 0;
            this.content.Text = "내용";
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Font = new System.Drawing.Font("Malgun Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.msg.ForeColor = System.Drawing.Color.White;
            this.msg.Location = new System.Drawing.Point(63, 364);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(52, 28);
            this.msg.TabIndex = 1;
            this.msg.Text = "내용";
            // 
            // Back
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(634, 490);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Back";
            this.Text = "Back";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label content;
        private System.Windows.Forms.Label msg;
    }
}