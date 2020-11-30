namespace ServerWinform
{
    partial class Form2
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
            this.listboxCommands = new System.Windows.Forms.ListBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_appRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_appName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_appSave = new System.Windows.Forms.Button();
            this.tbox_appPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbox_batData = new System.Windows.Forms.TextBox();
            this.btn_batSelect = new System.Windows.Forms.Button();
            this.btn_batRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_batName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_batSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxCommands
            // 
            this.listboxCommands.FormattingEnabled = true;
            this.listboxCommands.ItemHeight = 12;
            this.listboxCommands.Items.AddRange(new object[] {
            "测试数据1",
            "测试数据2",
            "测试数据3"});
            this.listboxCommands.Location = new System.Drawing.Point(12, 12);
            this.listboxCommands.Name = "listboxCommands";
            this.listboxCommands.Size = new System.Drawing.Size(113, 172);
            this.listboxCommands.TabIndex = 1;
            this.listboxCommands.SelectedIndexChanged += new System.EventHandler(this.listboxCommands_SelectedIndexChanged);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(12, 211);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(113, 23);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "移除";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_appRun);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbox_appName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_appSave);
            this.panel1.Controls.Add(this.tbox_appPath);
            this.panel1.Location = new System.Drawing.Point(140, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 70);
            this.panel1.TabIndex = 3;
            // 
            // btn_appRun
            // 
            this.btn_appRun.Location = new System.Drawing.Point(281, 37);
            this.btn_appRun.Name = "btn_appRun";
            this.btn_appRun.Size = new System.Drawing.Size(75, 23);
            this.btn_appRun.TabIndex = 4;
            this.btn_appRun.Text = "执行应用";
            this.btn_appRun.UseVisualStyleBackColor = true;
            this.btn_appRun.Click += new System.EventHandler(this.btn_appRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "存储名称:";
            // 
            // tbox_appName
            // 
            this.tbox_appName.Location = new System.Drawing.Point(107, 36);
            this.tbox_appName.Name = "tbox_appName";
            this.tbox_appName.Size = new System.Drawing.Size(87, 21);
            this.tbox_appName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "应用路径:";
            // 
            // btn_appSave
            // 
            this.btn_appSave.Location = new System.Drawing.Point(200, 36);
            this.btn_appSave.Name = "btn_appSave";
            this.btn_appSave.Size = new System.Drawing.Size(75, 23);
            this.btn_appSave.TabIndex = 0;
            this.btn_appSave.Text = "保存";
            this.btn_appSave.UseVisualStyleBackColor = true;
            this.btn_appSave.Click += new System.EventHandler(this.btn_appSave_Click);
            // 
            // tbox_appPath
            // 
            this.tbox_appPath.Location = new System.Drawing.Point(107, 9);
            this.tbox_appPath.Name = "tbox_appPath";
            this.tbox_appPath.Size = new System.Drawing.Size(249, 21);
            this.tbox_appPath.TabIndex = 0;
            this.tbox_appPath.Leave += new System.EventHandler(this.tbox_appPath_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbox_batData);
            this.panel2.Controls.Add(this.btn_batSelect);
            this.panel2.Controls.Add(this.btn_batRun);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbox_batName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_batSave);
            this.panel2.Location = new System.Drawing.Point(140, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 220);
            this.panel2.TabIndex = 5;
            // 
            // tbox_batData
            // 
            this.tbox_batData.Location = new System.Drawing.Point(18, 73);
            this.tbox_batData.Multiline = true;
            this.tbox_batData.Name = "tbox_batData";
            this.tbox_batData.Size = new System.Drawing.Size(338, 132);
            this.tbox_batData.TabIndex = 6;
            // 
            // btn_batSelect
            // 
            this.btn_batSelect.Location = new System.Drawing.Point(107, 7);
            this.btn_batSelect.Name = "btn_batSelect";
            this.btn_batSelect.Size = new System.Drawing.Size(40, 23);
            this.btn_batSelect.TabIndex = 5;
            this.btn_batSelect.Text = "...";
            this.btn_batSelect.UseVisualStyleBackColor = true;
            this.btn_batSelect.Click += new System.EventHandler(this.btn_batSelect_Click);
            // 
            // btn_batRun
            // 
            this.btn_batRun.Location = new System.Drawing.Point(281, 36);
            this.btn_batRun.Name = "btn_batRun";
            this.btn_batRun.Size = new System.Drawing.Size(75, 23);
            this.btn_batRun.TabIndex = 4;
            this.btn_batRun.Text = "执行bat";
            this.btn_batRun.UseVisualStyleBackColor = true;
            this.btn_batRun.Click += new System.EventHandler(this.btn_batRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "存储名称:";
            // 
            // tbox_batName
            // 
            this.tbox_batName.Location = new System.Drawing.Point(107, 36);
            this.tbox_batName.Name = "tbox_batName";
            this.tbox_batName.Size = new System.Drawing.Size(87, 21);
            this.tbox_batName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "bat 路径:";
            // 
            // btn_batSave
            // 
            this.btn_batSave.Location = new System.Drawing.Point(200, 36);
            this.btn_batSave.Name = "btn_batSave";
            this.btn_batSave.Size = new System.Drawing.Size(75, 23);
            this.btn_batSave.TabIndex = 0;
            this.btn_batSave.Text = "保存";
            this.btn_batSave.UseVisualStyleBackColor = true;
            this.btn_batSave.Click += new System.EventHandler(this.btn_batSave_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(517, 334);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.listboxCommands);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "远程执行指令";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxCommands;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_appPath;
        private System.Windows.Forms.Button btn_appRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_appName;
        private System.Windows.Forms.Button btn_appSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_batSelect;
        private System.Windows.Forms.Button btn_batRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_batName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_batSave;
        private System.Windows.Forms.TextBox tbox_batData;
    }
}