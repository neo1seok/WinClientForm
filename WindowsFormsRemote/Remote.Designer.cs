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
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.conStatus = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(97, 43);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(227, 25);
            this.textBox_ip.TabIndex = 0;
           
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
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(359, 43);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(137, 25);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "연결";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // conStatus
            // 
            this.conStatus.Location = new System.Drawing.Point(12, 419);
            this.conStatus.Name = "conStatus";
            this.conStatus.ReadOnly = true;
            this.conStatus.Size = new System.Drawing.Size(749, 25);
            this.conStatus.TabIndex = 3;
            // 
            // results
            // 
            this.results.FormattingEnabled = true;
            this.results.ItemHeight = 15;
            this.results.Location = new System.Drawing.Point(12, 115);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(749, 289);
            this.results.TabIndex = 4;
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 456);
            this.Controls.Add(this.results);
            this.Controls.Add(this.conStatus);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ip);
            this.Name = "Remote";
            this.Text = "RemoteClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Remote_FormClosed);
            this.Load += new System.EventHandler(this.Remote_Load);
        
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox conStatus;
        private System.Windows.Forms.ListBox results;
    }
}

