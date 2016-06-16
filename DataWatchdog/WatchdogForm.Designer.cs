namespace DataWatchdog
{
    partial class WatchdogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchdogForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoLaunchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRebootMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.notifyMessage = new System.Windows.Forms.Label();
            this.closeNotifyBtn = new System.Windows.Forms.Button();
            this.rebootBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Data Watchdog";
            this.trayIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLaunchMenuItem,
            this.autoRebootMenuItem,
            this.toolStripSeparator1,
            this.resetMenuItem,
            this.exitMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 98);
            // 
            // autoLaunchMenuItem
            // 
            this.autoLaunchMenuItem.Name = "autoLaunchMenuItem";
            this.autoLaunchMenuItem.Size = new System.Drawing.Size(181, 22);
            this.autoLaunchMenuItem.Text = "Start with Windows";
            this.autoLaunchMenuItem.Click += new System.EventHandler(this.autoLaunchMenuItem_Click);
            // 
            // autoRebootMenuItem
            // 
            this.autoRebootMenuItem.Name = "autoRebootMenuItem";
            this.autoRebootMenuItem.Size = new System.Drawing.Size(181, 22);
            this.autoRebootMenuItem.Text = "Auto Reboot";
            this.autoRebootMenuItem.Click += new System.EventHandler(this.autoShutdownMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.Size = new System.Drawing.Size(181, 22);
            this.resetMenuItem.Text = "Reset";
            this.resetMenuItem.Click += new System.EventHandler(this.resetMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::DataWatchdog.Properties.Resources.watch_dog;
            this.pictureBox.Location = new System.Drawing.Point(12, 18);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(50, 50);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // notifyMessage
            // 
            this.notifyMessage.AutoSize = true;
            this.notifyMessage.ForeColor = System.Drawing.Color.Red;
            this.notifyMessage.Location = new System.Drawing.Point(68, 20);
            this.notifyMessage.Name = "notifyMessage";
            this.notifyMessage.Size = new System.Drawing.Size(79, 12);
            this.notifyMessage.TabIndex = 2;
            this.notifyMessage.Text = "Notify message.";
            // 
            // closeNotifyBtn
            // 
            this.closeNotifyBtn.Location = new System.Drawing.Point(268, 2);
            this.closeNotifyBtn.Name = "closeNotifyBtn";
            this.closeNotifyBtn.Size = new System.Drawing.Size(23, 23);
            this.closeNotifyBtn.TabIndex = 3;
            this.closeNotifyBtn.Text = "x";
            this.closeNotifyBtn.UseVisualStyleBackColor = true;
            this.closeNotifyBtn.Click += new System.EventHandler(this.closeNotifyBtn_Click);
            // 
            // rebootBtn
            // 
            this.rebootBtn.Location = new System.Drawing.Point(215, 51);
            this.rebootBtn.Name = "rebootBtn";
            this.rebootBtn.Size = new System.Drawing.Size(75, 23);
            this.rebootBtn.TabIndex = 4;
            this.rebootBtn.Text = "Reboot";
            this.rebootBtn.UseVisualStyleBackColor = true;
            this.rebootBtn.Click += new System.EventHandler(this.rebootBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(106, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Watchdog";
            // 
            // WatchdogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 76);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rebootBtn);
            this.Controls.Add(this.closeNotifyBtn);
            this.Controls.Add(this.notifyMessage);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WatchdogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Watchdog";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.WatchdogForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem resetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label notifyMessage;
        private System.Windows.Forms.Button closeNotifyBtn;
        private System.Windows.Forms.Button rebootBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem autoRebootMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem autoLaunchMenuItem;
    }
}

