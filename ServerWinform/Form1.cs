using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MiddleProject;
using MiddleProject.model;
using Server;
using ServerWinform.model;

namespace ServerWinform
{
    public partial class Form1 : Form
    {
        private Form form2;
        private Form form3;
        public ServerController server { get; private set; }
        private Dictionary<IPEndPoint,UIClientItem> clientDic = new Dictionary<IPEndPoint, UIClientItem>();
        public const int IMAGE_OnLine = 1;
        public const int IMAGE_Offline = 2;
        
        public Form1()
        {
            InitializeComponent();
        }

        #region winform事件

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.listView1.LargeImageList = this.imageList1;
            
            start();
            //MessageBox.Show(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop();
        }

        private void buttonOpenapp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("未选中客户端");
                return;
            }
            
            if (isSelectOnline())
            {
                form2.ShowDialog();
                return;
            }

            MessageBox.Show("选项中存在离线状态的客户端");

        }

        private void buttonCloseapp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("未选中客户端");
                return;
            }
            
            if (isSelectOnline())
            {
                closeApp();
                return;
            }
            MessageBox.Show("选项中存在离线状态的客户端");
            
        }

        private void buttonClearapp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("未选中客户端");
                return;
            }
            
            if (isSelectOnline())
            {
                form3.ShowDialog();
                return;
            }
            MessageBox.Show("选项中存在离线状态的客户端");
            
        }
        private void but_uninstallClient_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("未选中客户端");
                return;
            }
            
            if (isSelectOnline())
            {
                DialogResult dialogResult = MessageBox.Show("即将失去对客户端的控制，是否确定卸载？","提示",MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    uninstallClient();
                }
                return;
            }
            
            MessageBox.Show("选项中存在离线状态的客户端");
            
        }

        private void checkSelectall_CheckedChanged(object sender, EventArgs e)
        {
            selectedAll(checkSelectall.Checked);
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                checkSelectall.CheckState = CheckState.Unchecked;
            }
        }
        
        #endregion

        private void start()
        {
            try
            {
                server = new ServerController(10802);
                form2 = new Form2(this);
                form3 = new Form3(this);
                
                server.AcAddclient += clientOnline;
                server.AcRemoveclient += clientOffline;
                //LogUtil.callback += ((s) => { System.Diagnostics.Debug.WriteLine(s); });
                server.BeginReceive();
            }
            catch (Exception e)
            {
                LogUtil.Error(e.Message);
            }
        }

        private void stop()
        {
            if(server!=null)
                server.Close();
        }

        private void uninstallClient()
        {
            foreach (IPEndPoint ip in getSelectClients())
            {
                server.Send(OrderCode.Uninst, ip);
            }
        }

        private void closeApp()
        {
            foreach (IPEndPoint ip in getSelectClients())
            {
                server.Send(OrderCode.CloseApp, ip);
            }
        }

        private void clientOnline(IPEndPoint ip)
        {
            UIClientItem item;
            if (!clientDic.TryGetValue(ip, out item))
            {
                item = new UIClientItem(ip);
                clientDic.Add(ip,item);
                sortClientUI();
            }
            item.SetOnline(true);
            UI_updateOnlineCount();
        }
        
        private void clientOnline(ListViewItem item)
        {
            foreach (UIClientItem uiItem in clientDic.Values.ToList())
            {
                if (uiItem.viewItem.Equals(item))
                {
                    uiItem.SetOnline(true);
                }
            }

            UI_updateOnlineCount();
        }

        private void clientOffline(IPEndPoint ip)
        {
            UIClientItem item;
            if (clientDic.TryGetValue(ip,out item))
            {
                item.SetOnline(false);
            }

            UI_updateOnlineCount();
        }
        
        private void clientOffline(ListViewItem item)
        {
            foreach (UIClientItem uiItem in clientDic.Values.ToList())
            {
                if (uiItem.viewItem.Equals(item))
                {
                    uiItem.SetOnline(false);
                }
            }

            UI_updateOnlineCount();
        }

        private int getOnlineCount()
        {
            int index = 0;
            foreach (UIClientItem uiItem in clientDic.Values.ToList())
            {
                if (uiItem.status)
                {
                    index++;
                }
            }

            return index;
        }

        delegate void MsgCallBackInvoke();
        private void UI_updateOnlineCount()
        {
            this.Invoke(new MsgCallBackInvoke(() =>
            {
                lab_clientCount.Text = string.Format("{0}/{1}", getOnlineCount(), clientDic.Count);
            }));
            //lab_clientCount.Text = string.Format("{0}/{1}", getOnlineCount(), clientDic.Count);
        }

        private void selectedAll(bool status)
        {
            listView1.Focus();
            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = status;
            }
        }

        private void sortClientUI()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var client in clientDic.sort())
            {
                listView1.Items.Add(client.Value.viewItem);
            }
            listView1.EndUpdate();
        }
        
        public List<IPEndPoint> getSelectClients()
        {
            List<IPEndPoint> clients = new List<IPEndPoint>();
            foreach (ListViewItem viewItem in listView1.SelectedItems)
            {
                IPEndPoint ip = getClientIp(viewItem);
                if(ip!=null)
                    clients.Add(ip);
            }

            return clients;
        }

        public bool isSelectOnline()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (item.ImageIndex == IMAGE_Offline)
                    return false;
            }

            return true;
        }

        private IPEndPoint getClientIp(ListViewItem item)
        {
            foreach (UIClientItem clientItem in clientDic.Values)
            {
                if (clientItem.viewItem == item)
                {
                    return clientItem.ip;
                }
            }

            return null;
        }

        Random _random = new Random();
        private void test_addClient_Click_1(object sender, EventArgs e)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.5."+_random.Next(0,100)),10020);
            clientOnline(ip);
        }

        private void test_clientsOnLine_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                clientOnline(item);
            }
        }

        private void test_clientsOffLine_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                clientOffline(item);
            }
        }

        private void test_closeApp_Click(object sender, EventArgs e)
        {
            string appName = test_textCloseAppName.Text;
            foreach (IPEndPoint ip in getSelectClients())
            {
                server.Send(OrderCode.CloseApp,appName,ip);
            }
            
        }
    }
}
