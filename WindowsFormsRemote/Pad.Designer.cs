namespace WindowsFormsRemote
{
    partial class Pad
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
            this.components = new System.ComponentModel.Container();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timerInvoke = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.TextBox();
            this.btn_center = new System.Windows.Forms.Button();
            this.button_toggle = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(6, 389);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(614, 52);
            this.textBoxStatus.TabIndex = 0;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timerInvoke
            // 
            this.timerInvoke.Interval = 10;
            this.timerInvoke.Tick += new System.EventHandler(this.timerInvoke_Tick);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.DimGray;
            this.panel.Location = new System.Drawing.Point(29, 75);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Multiline = true;
            this.panel.Name = "panel";
            this.panel.ReadOnly = true;
            this.panel.Size = new System.Drawing.Size(561, 293);
            this.panel.TabIndex = 1;
            this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            this.panel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panel_KeyDown);
            this.panel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.panel_KeyPress);
            this.panel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.panel_KeyUp);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            this.panel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pane_MouseWheel);
            // 
            // btn_center
            // 
            this.btn_center.Location = new System.Drawing.Point(491, 13);
            this.btn_center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_center.Name = "btn_center";
            this.btn_center.Size = new System.Drawing.Size(125, 41);
            this.btn_center.TabIndex = 2;
            this.btn_center.Text = "센터정렬";
            this.btn_center.UseVisualStyleBackColor = true;
            this.btn_center.Click += new System.EventHandler(this.btn_center_Click);
            // 
            // button_toggle
            // 
            this.button_toggle.Location = new System.Drawing.Point(360, 13);
            this.button_toggle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_toggle.Name = "button_toggle";
            this.button_toggle.Size = new System.Drawing.Size(125, 41);
            this.button_toggle.TabIndex = 2;
            this.button_toggle.Text = "시작";
            this.button_toggle.UseVisualStyleBackColor = true;
            this.button_toggle.Click += new System.EventHandler(this.button_toggle_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 458);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(633, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "주소";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(66, 13);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(227, 25);
            this.textBox_ip.TabIndex = 4;
            // 
            // Pad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(633, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.button_toggle);
            this.Controls.Add(this.btn_center);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.textBoxStatus);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Pad";
            this.Text = "Pad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Pad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pad_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pad_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Pad_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Pad_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Timer timerInvoke;
        private System.Windows.Forms.TextBox panel;
		private System.Windows.Forms.Button btn_center;
		private System.Windows.Forms.Button button_toggle;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ip;
    }
}