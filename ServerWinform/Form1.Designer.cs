namespace ServerWinform
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonOpenapp = new System.Windows.Forms.Button();
            this.buttonCloseapp = new System.Windows.Forms.Button();
            this.buttonClearapp = new System.Windows.Forms.Button();
            this.checkSelectall = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.测试功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test_addClient = new System.Windows.Forms.ToolStripMenuItem();
            this.test_clientsOnLine = new System.Windows.Forms.ToolStripMenuItem();
            this.test_clientsOffLine = new System.Windows.Forms.ToolStripMenuItem();
            this.test_closeApp = new System.Windows.Forms.ToolStripMenuItem();
            this.test_textCloseAppName = new System.Windows.Forms.ToolStripTextBox();
            this.but_uninstallClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_clientCount = new System.Windows.Forms.Label();
            this.listView1 = new ServerWinform.DoubleBufferListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon1.ico");
            this.imageList1.Images.SetKeyName(1, "com_online.ico");
            this.imageList1.Images.SetKeyName(2, "com_offline.ico");
            // 
            // buttonOpenapp
            // 
            this.buttonOpenapp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenapp.Location = new System.Drawing.Point(417, 122);
            this.buttonOpenapp.Name = "buttonOpenapp";
            this.buttonOpenapp.Size = new System.Drawing.Size(103, 29);
            this.buttonOpenapp.TabIndex = 2;
            this.buttonOpenapp.Text = "执行应用";
            this.buttonOpenapp.UseVisualStyleBackColor = true;
            this.buttonOpenapp.Click += new System.EventHandler(this.buttonOpenapp_Click);
            // 
            // buttonCloseapp
            // 
            this.buttonCloseapp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCloseapp.Location = new System.Drawing.Point(417, 157);
            this.buttonCloseapp.Name = "buttonCloseapp";
            this.buttonCloseapp.Size = new System.Drawing.Size(103, 29);
            this.buttonCloseapp.TabIndex = 3;
            this.buttonCloseapp.Text = "关闭所有应用";
            this.buttonCloseapp.UseVisualStyleBackColor = true;
            this.buttonCloseapp.Click += new System.EventHandler(this.buttonCloseapp_Click);
            // 
            // buttonClearapp
            // 
            this.buttonClearapp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearapp.Location = new System.Drawing.Point(417, 228);
            this.buttonClearapp.Name = "buttonClearapp";
            this.buttonClearapp.Size = new System.Drawing.Size(103, 29);
            this.buttonClearapp.TabIndex = 4;
            this.buttonClearapp.Text = "清理应用";
            this.buttonClearapp.UseVisualStyleBackColor = true;
            this.buttonClearapp.Click += new System.EventHandler(this.buttonClearapp_Click);
            // 
            // checkSelectall
            // 
            this.checkSelectall.AutoSize = true;
            this.checkSelectall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkSelectall.Location = new System.Drawing.Point(417, 27);
            this.checkSelectall.Name = "checkSelectall";
            this.checkSelectall.Size = new System.Drawing.Size(54, 18);
            this.checkSelectall.TabIndex = 5;
            this.checkSelectall.Text = "全选";
            this.checkSelectall.UseVisualStyleBackColor = true;
            this.checkSelectall.CheckedChanged += new System.EventHandler(this.checkSelectall_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 测试功能ToolStripMenuItem
            // 
            this.测试功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test_addClient,
            this.test_clientsOnLine,
            this.test_clientsOffLine,
            this.test_closeApp});
            this.测试功能ToolStripMenuItem.Name = "测试功能ToolStripMenuItem";
            this.测试功能ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.测试功能ToolStripMenuItem.Text = "测试功能";
            this.测试功能ToolStripMenuItem.Visible = false;
            // 
            // test_addClient
            // 
            this.test_addClient.Name = "test_addClient";
            this.test_addClient.Size = new System.Drawing.Size(159, 22);
            this.test_addClient.Text = "Add client";
            this.test_addClient.Click += new System.EventHandler(this.test_addClient_Click_1);
            // 
            // test_clientsOnLine
            // 
            this.test_clientsOnLine.Name = "test_clientsOnLine";
            this.test_clientsOnLine.Size = new System.Drawing.Size(159, 22);
            this.test_clientsOnLine.Text = "Clients OnLine";
            this.test_clientsOnLine.Click += new System.EventHandler(this.test_clientsOnLine_Click);
            // 
            // test_clientsOffLine
            // 
            this.test_clientsOffLine.Name = "test_clientsOffLine";
            this.test_clientsOffLine.Size = new System.Drawing.Size(159, 22);
            this.test_clientsOffLine.Text = "Clients OffLine";
            this.test_clientsOffLine.Click += new System.EventHandler(this.test_clientsOffLine_Click);
            // 
            // test_closeApp
            // 
            this.test_closeApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test_textCloseAppName});
            this.test_closeApp.Name = "test_closeApp";
            this.test_closeApp.Size = new System.Drawing.Size(159, 22);
            this.test_closeApp.Text = "CloseApp";
            this.test_closeApp.Click += new System.EventHandler(this.test_closeApp_Click);
            // 
            // test_textCloseAppName
            // 
            this.test_textCloseAppName.Name = "test_textCloseAppName";
            this.test_textCloseAppName.Size = new System.Drawing.Size(100, 23);
            // 
            // but_uninstallClient
            // 
            this.but_uninstallClient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_uninstallClient.Location = new System.Drawing.Point(417, 261);
            this.but_uninstallClient.Name = "but_uninstallClient";
            this.but_uninstallClient.Size = new System.Drawing.Size(103, 29);
            this.but_uninstallClient.TabIndex = 7;
            this.but_uninstallClient.Text = "卸载客户端";
            this.but_uninstallClient.UseVisualStyleBackColor = true;
            this.but_uninstallClient.Click += new System.EventHandler(this.but_uninstallClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(414, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "客户端:";
            // 
            // lab_clientCount
            // 
            this.lab_clientCount.AutoSize = true;
            this.lab_clientCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_clientCount.ForeColor = System.Drawing.Color.Red;
            this.lab_clientCount.Location = new System.Drawing.Point(470, 48);
            this.lab_clientCount.Name = "lab_clientCount";
            this.lab_clientCount.Size = new System.Drawing.Size(28, 14);
            this.lab_clientCount.TabIndex = 9;
            this.lab_clientCount.Text = "0/0";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(392, 263);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(538, 302);
            this.Controls.Add(this.lab_clientCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_uninstallClient);
            this.Controls.Add(this.checkSelectall);
            this.Controls.Add(this.buttonClearapp);
            this.Controls.Add(this.buttonCloseapp);
            this.Controls.Add(this.buttonOpenapp);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "远程控制服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonOpenapp;
        private System.Windows.Forms.Button buttonCloseapp;
        private System.Windows.Forms.Button buttonClearapp;
        private System.Windows.Forms.CheckBox checkSelectall;
        private DoubleBufferListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 测试功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test_addClient;
        private System.Windows.Forms.ToolStripMenuItem test_clientsOnLine;
        private System.Windows.Forms.ToolStripMenuItem test_clientsOffLine;
        private System.Windows.Forms.Button but_uninstallClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_clientCount;
        private System.Windows.Forms.ToolStripMenuItem test_closeApp;
        private System.Windows.Forms.ToolStripTextBox test_textCloseAppName;


    }
}

