using System.Windows.Forms;

namespace ServerWinform
{
    public class DoubleBufferListView:ListView
    {
        public DoubleBufferListView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint,  true );
            UpdateStyles();
        }
    }
}