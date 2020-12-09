using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MiddleProject;
using MiddleProject.model;
using MiddleProject.utils;
using Newtonsoft.Json;
using ServerWinform.model;
using Server;

namespace ServerWinform
{
    public partial class Form3 : Form
    {
        private Dictionary<string,string> pathDic = new Dictionary<string, string>();
        private Form1 form1;
        
        public Form3(Form1 form1)
        {
            InitializeComponent();
            listboxPaths.Items.Clear();
            loadData();
            this.form1 = form1;
        }

        private void loadData()
        {
            Dictionary<string,string> pathData = LoadData.Instance.getDeletepathData();
            if (pathData != null)
            {
                pathDic = pathData;
                foreach (string item in pathDic.Keys)
                    listboxPaths.Items.Add(item);
            }
            else
                pathDic = new Dictionary<string, string>();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            removePath(listboxPaths.SelectedItem.ToString());
        }

        private void btn_pathSave_Click(object sender, EventArgs e)
        {
            if (tbox_pathName.Text == String.Empty)
                return;
            addPath(tbox_pathName.Text, tbox_pathData.Text);
        }

        private void btn_pathDelete_Click(object sender, EventArgs e)
        {
            string data = tbox_pathData.Text;
            List<IPEndPoint> selectClients = form1.getSelectClients();
            foreach (IPEndPoint ip in selectClients)
                form1.server.Send(OrderCode.DeleteApp,data,ip);
        }

        private void listboxPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listboxPaths.SelectedItem == null)
                return;
            tbox_pathName.Text = "";
            tbox_pathData.Text = "";

            string name = listboxPaths.SelectedItem.ToString();
            string url = getPath(name);
            if(url==null)
                return;
            tbox_pathName.Text = name;
            tbox_pathData.Text = url;
        }
        
        private void tbox_pathData_Leave(object sender, EventArgs e)
        {
            tbox_pathName.Text = ToolForUrl.getDirEndName(tbox_pathData.Text);
        }

        private void addPath(string name, string url)
        {
            string _url;
            if (pathDic.TryGetValue(name, out _url))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("\"{0}\"已存在,是否替换",name),"提示",MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    _url = url;
                    saveData();
                }
                return;
            }

            pathDic.Add(name,url);
            listboxPaths.Items.Add(name);
            saveData();
        }
        
        private void removePath(string name)
        {
            if (pathDic.ContainsKey(name))
            {
                listboxPaths.Items.Remove(name);
                pathDic.Remove(name);
                saveData();
            }
        }
        
        private string getPath(string name)
        {
            string path;
            pathDic.TryGetValue(name,out path);
            return path;
        }
        
        private void saveData()
        {
            LoadData.Instance.SaveData(pathDic);
        }
    }
}
