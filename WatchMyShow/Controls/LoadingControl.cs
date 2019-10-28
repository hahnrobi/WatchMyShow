using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchMyShow.Controls
{
    class LoadingControl : Panel
    {
        public LoadingControl(Form parent)
        {
            this.Size = new Size(parent.Size.Width, parent.Size.Height);
            this.Location = new Point(0, 0);
            this.BackColor = DefaultBackColor;

        }
        public void Close()
        {
            this.Close();
        }
    }
}
