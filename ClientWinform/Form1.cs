using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client;
using Client.accept;
using MiddleProject;
using MiddleProject.impl;

namespace ClientWinform
{

    public partial class Form1 : Form
    {
        private ClientControl _clientControl;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            Start();
            
        }
        
        private void Start()
        {
            try
            {
                label_runStatus.Text = "运行中...";
                button_Start.Enabled = false;
                //_clientControl.msgCallback += msgCallback;
                _clientControl = new ClientControl(10801, 10802);
                
                LogUtil.callback += msgCallback;
                (AssemblyHandler.GetInstance<CloseApp>() as CloseApp).callback += HideWindow;
                (AssemblyHandler.GetInstance<Uninstall>() as Uninstall).callback += Quit;
                
                (AssemblyHandler.GetInstance<Uninstall>() as Uninstall).localUrl = Application.ExecutablePath;
                
                
                _clientControl.BeginReceive();
            }
            catch (Exception e)
            {
                LogUtil.Error(e);
                label_runStatus.Text = "error!!";
                Stop();
            }
        }

        delegate void MsgCallBackInvoke(string msg);
        private void msgCallback(string msg)
        {
            this.Invoke(new MsgCallBackInvoke(delegate(string m)
            {
                textBox_infoPanel.AppendText(m+Environment.NewLine);
            }),msg);
            
            //textBox_infoPanel.AppendText(Environment.NewLine);
        }

        private void Stop()
        {
            label_runStatus.Text = "关闭";
            button_Start.Enabled = true;

            if (_clientControl != null)
            {
                _clientControl.Close();
            }
        }

        //重写关闭按钮
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                HideWindow();
                return;
            }
            base.WndProc(ref m);
        }

        //菜单栏退出按钮
        private void MenuItem_Close_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);
            this.Close();
        }

        //任务图标按钮
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                ShowWindow();
            }
        }

        private void ShowWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void HideWindow()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Stop();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Quit()
        {
            Stop();
            Close();
        }
    }
}
