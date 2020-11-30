namespace ClientWinform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label_runStatus = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_infoPanel = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "远程控制客户端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Text = "菜单";
            // 
            // MenuItem_Close
            // 
            this.MenuItem_Close.Name = "MenuItem_Close";
            this.MenuItem_Close.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Close.Text = "退出";
            this.MenuItem_Close.Click += new System.EventHandler(this.MenuItem_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "运行状态:";
            // 
            // label_runStatus
            // 
            this.label_runStatus.AutoSize = true;
            this.label_runStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_runStatus.ForeColor = System.Drawing.Color.Red;
            this.label_runStatus.Location = new System.Drawing.Point(85, 16);
            this.label_runStatus.Name = "label_runStatus";
            this.label_runStatus.Size = new System.Drawing.Size(35, 14);
            this.label_runStatus.TabIndex = 3;
            this.label_runStatus.Text = "关闭";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(244, 12);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "开始侦听";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // textBox_infoPanel
            // 
            this.textBox_infoPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_infoPanel.Location = new System.Drawing.Point(12, 46);
            this.textBox_infoPanel.Multiline = true;
            this.textBox_infoPanel.Name = "textBox_infoPanel";
            this.textBox_infoPanel.ReadOnly = true;
            this.textBox_infoPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_infoPanel.Size = new System.Drawing.Size(307, 107);
            this.textBox_infoPanel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(331, 165);
            this.Controls.Add(this.textBox_infoPanel);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_runStatus);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "远程控制客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Close;
        private System.Windows.Forms.Label label_runStatus;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_infoPanel;
    }
}

