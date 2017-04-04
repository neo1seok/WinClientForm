namespace WindowsFormsRemote
{
    partial class Remote
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "주소";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "연결";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 451);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Remote";
            this.Text = "RemoteClient";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Remote_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Remote_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Remote_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Remote_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Remote_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Remote_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

