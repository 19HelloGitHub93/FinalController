namespace ServerWinform
{
    partial class Form3
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
            this.listboxPaths = new System.Windows.Forms.ListBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_pathDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_pathName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_pathSave = new System.Windows.Forms.Button();
            this.tbox_pathData = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxPaths
            // 
            this.listboxPaths.FormattingEnabled = true;
            this.listboxPaths.ItemHeight = 12;
            this.listboxPaths.Items.AddRange(new object[] {
            "测试数据1",
            "测试数据2",
            "测试数据3"});
            this.listboxPaths.Location = new System.Drawing.Point(12, 12);
            this.listboxPaths.Name = "listboxPaths";
            this.listboxPaths.Size = new System.Drawing.Size(113, 172);
            this.listboxPaths.TabIndex = 1;
            this.listboxPaths.SelectedIndexChanged += new System.EventHandler(this.listboxPaths_SelectedIndexChanged);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(12, 190);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(113, 23);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "移除";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_pathDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbox_pathName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_pathSave);
            this.panel1.Controls.Add(this.tbox_pathData);
            this.panel1.Location = new System.Drawing.Point(140, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 108);
            this.panel1.TabIndex = 3;
            // 
            // btn_pathDelete
            // 
            this.btn_pathDelete.Location = new System.Drawing.Point(281, 37);
            this.btn_pathDelete.Name = "btn_pathDelete";
            this.btn_pathDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_pathDelete.TabIndex = 4;
            this.btn_pathDelete.Text = "执行删除";
            this.btn_pathDelete.UseVisualStyleBackColor = true;
            this.btn_pathDelete.Click += new System.EventHandler(this.btn_pathDelete_Click);
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
            // tbox_pathName
            // 
            this.tbox_pathName.Location = new System.Drawing.Point(107, 36);
            this.tbox_pathName.Name = "tbox_pathName";
            this.tbox_pathName.Size = new System.Drawing.Size(87, 21);
            this.tbox_pathName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标路径:";
            // 
            // btn_pathSave
            // 
            this.btn_pathSave.Location = new System.Drawing.Point(200, 36);
            this.btn_pathSave.Name = "btn_pathSave";
            this.btn_pathSave.Size = new System.Drawing.Size(75, 23);
            this.btn_pathSave.TabIndex = 0;
            this.btn_pathSave.Text = "保存";
            this.btn_pathSave.UseVisualStyleBackColor = true;
            this.btn_pathSave.Click += new System.EventHandler(this.btn_pathSave_Click);
            // 
            // tbox_pathData
            // 
            this.tbox_pathData.Location = new System.Drawing.Point(107, 9);
            this.tbox_pathData.Name = "tbox_pathData";
            this.tbox_pathData.Size = new System.Drawing.Size(249, 21);
            this.tbox_pathData.TabIndex = 0;
            this.tbox_pathData.Leave += new System.EventHandler(this.tbox_pathData_Leave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 230);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.listboxPaths);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "远程执行指令";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxPaths;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_pathData;
        private System.Windows.Forms.Button btn_pathDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_pathName;
        private System.Windows.Forms.Button btn_pathSave;
    }
}