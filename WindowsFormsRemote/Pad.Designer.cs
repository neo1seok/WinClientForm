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
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(12, 247);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(473, 26);
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
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.Location = new System.Drawing.Point(6, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(479, 229);
            this.panel.TabIndex = 1;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // Pad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 285);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.textBoxStatus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Panel panel;
    }
}