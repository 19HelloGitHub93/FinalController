using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MiddleProject;
using MiddleProject.model;
using Newtonsoft.Json;
using ServerWinform.model;
using Server;

namespace ServerWinform
{
    public partial class Form2 : Form
    {
        private Dictionary<string, AppItem> commandDic;
        private Form1 form1;
        
        public Form2(Form1 form1)
        {
            InitializeComponent();
            listboxCommands.Items.Clear();
            loadData();
            this.form1 = form1;
        }

        private void loadData()
        {
            Dictionary<string,AppItem> commandData = LoadData.Instance.getCommandData();
            if (commandData != null)
            {
                commandDic = commandData;
                foreach (string item in commandDic.Keys)
                    listboxCommands.Items.Add(item);
            }
            else
                commandDic = new Dictionary<string, AppItem>();
        }

        private void btn_appRun_Click(object sender, EventArgs e)
        {
            string d = tbox_appPath.Text;
            if (d == String.Empty)
                return;
            List<IPEndPoint> cliens = form1.getSelectClients();
            foreach (IPEndPoint ip in cliens)
            {
                Data data = new Data(OrderCode.App,d);
                form1.server.Send(data,ip);
            }
        }
        
        private void btn_appSave_Click(object sender, EventArgs e)
        {
            string data = tbox_appPath.Text;
            if (data == String.Empty)
                return;
            AppItem appItem = new AppItem(tbox_appName.Text,data,AppType.Application);
            addCommand(appItem);
        }

        private void btn_batSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*bat*)|*.bat";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;
                tbox_batName.Text = fileDialog.SafeFileName;
                tbox_batData.Text = File.ReadAllText(path,Encoding.GetEncoding("gb2312"));
            }
        }

        private void btn_batSave_Click(object sender, EventArgs e)
        {
           
            if (tbox_batName.Text == String.Empty)
                return;
             string data = tbox_batData.Text;
            AppItem batItem = new AppItem(tbox_batName.Text,data,AppType.Bat);
            addCommand(batItem);
        }

        private void btn_batRun_Click(object sender, EventArgs e)
        {
            string d = tbox_batData.Text;
            if (d == String.Empty)
                return;
            List<IPEndPoint> cliens = form1.getSelectClients();
            foreach (IPEndPoint ip in cliens)
            {
                Data data = new Data(OrderCode.Cmd,d);
                form1.server.Send(data,ip);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            removeCommand(listboxCommands.SelectedItem.ToString());
        }
        private void listboxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listboxCommands.SelectedItem == null)
                return;
            tbox_appName.Text = "";
            tbox_appPath.Text = "";
            tbox_batName.Text = "";
            tbox_batData.Text = "";
            
            AppItem appItem = getCommand(listboxCommands.SelectedItem.ToString());
            
            if(appItem==null)
                return;
            
            if (appItem.appType == AppType.Application)
            {
                tbox_appName.Text = appItem.name;
                tbox_appPath.Text = appItem.data;
            }

            if (appItem.appType == AppType.Bat)
            {
                tbox_batName.Text = appItem.name;
                tbox_batData.Text = appItem.data;
            }
        }
        
        private void tbox_appPath_Leave(object sender, EventArgs e)
        {
            tbox_appName.Text = ToolForUrl.getDirEndName(tbox_appPath.Text);
        }

        private void addCommand(AppItem app)
        {
            AppItem defaultApp;
            if (commandDic.TryGetValue(app.name, out defaultApp))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("\"{0}\"已存在,是否替换",app.name),"提示",MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    defaultApp.data = app.data;
                    defaultApp.appType = app.appType;
                    saveData();
                }
                return;
            }

            commandDic.Add(app.name,app);
            listboxCommands.Items.Add(app.name);
            saveData();
        }

        private void removeCommand(string appName)
        {
            if (commandDic.ContainsKey(appName))
            {
                listboxCommands.Items.Remove(appName);
                commandDic.Remove(appName);
                saveData();
            }
        }

        private AppItem getCommand(string appname)
        {
            AppItem app;
            commandDic.TryGetValue(appname,out app);
            return app;
        }

        private void saveData()
        {
           LoadData.Instance.SaveData(commandDic);
        }
    }
}
