using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WatchMyShow
{
    class TvProgramControl : Panel
    {
        public TvProgramControl()
        {
            BackColor = Color.White;
            Size = new Size(303, 80);
            BorderStyle = BorderStyle.FixedSingle;
            Label labelTitle = new Label()
            {
                Location = new System.Drawing.Point(41, 4),
                Size = new Size(177, 21),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                Text = "Frakk a macskák réme"
            };
            PictureBox pictureKorhatar = new PictureBox()
            {
                Image = new Bitmap(Properties.Resources._12felett)
            };
            Controls.Add(labelTitle);
            Controls.Add(pictureKorhatar);
        }
    }
}
