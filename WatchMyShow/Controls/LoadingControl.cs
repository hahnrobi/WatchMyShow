using System.Drawing;
using System.Windows.Forms;

namespace WatchMyShow.Controls
{
    internal class LoadingControl : Panel
    {
        public LoadingControl(Form parent)
        {
            Size = new Size(parent.Size.Width, parent.Size.Height);
            Location = new Point(0, 0);
            BackColor = DefaultBackColor;

        }
        public void Close()
        {
            Close();
        }
    }
}
