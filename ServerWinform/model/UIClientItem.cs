using System.Net;
using System.Windows.Forms;
using MiddleProject;
using MiddleProject.utils;

namespace ServerWinform.model
{
    public class UIClientItem
    {
        //public int id;
        public IPEndPoint ip{
            get;
            private set;
        }

        public bool status
        {
            get;
            private set;
        }

        public ListViewItem viewItem
        {
            get;
            private set;
        }
        
        public UIClientItem(IPEndPoint ip)
        {
            this.ip = ip;
            this.viewItem = new ListViewItem();
            this.viewItem.Text = ToolForIp.getChildIp(ip.Address.ToString(), 4);
            //this.id = Convert.ToInt32(sid);
        }

        public void SetOnline(bool status)
        {
            this.status = status;
            this.viewItem.ImageIndex = status ? Form1.IMAGE_OnLine : Form1.IMAGE_Offline;
        }
    }
}