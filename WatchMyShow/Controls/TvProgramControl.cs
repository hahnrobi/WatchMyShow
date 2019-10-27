using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    class TvProgramControl : Panel
    {
        
        private Label labelTitle;
        private Label labelGenre;
        private Label labelStartTime;
        private Label labelTimeLength;
        private PictureBox pictureKorhatar;
        private TvProgram program;
                
        public TvProgramControl(TvProgram program)
        {
            this.program = program;
            InitializeComponent();
        }
        private Bitmap getAgeLimitPic()
        {
            switch (program.AgeLimit)
            {
                case AgeLimit.NoLimit:
                    return new Bitmap(Properties.Resources.nokorhatar);
                case AgeLimit.Above6:
                    return new Bitmap(Properties.Resources._6felett);
                case AgeLimit.Above12:
                    return new Bitmap(Properties.Resources._12felett);
                case AgeLimit.Above16:
                    return new Bitmap(Properties.Resources._16felett);
                case AgeLimit.Above18:
                    return new Bitmap(Properties.Resources._18felett);
                default:
                    return new Bitmap(Properties.Resources.nokorhatar);
            }
        }
        private void InitializeComponent()
        {
            BackColor = Color.White;
            Size = new Size(303, 80);
            BorderStyle = BorderStyle.FixedSingle;
            labelTitle = new Label()
            {
                Location = new System.Drawing.Point(55, 4),
                Size = new Size(177, 21),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                Text = program.Title
            };
            labelGenre = new Label()
            {
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular),
                Location = new Point(56, 28),
                Size = new Size(156, 30),
                Text = TvProgramManager.GetGenresAsString(program.Genre)
            };

            labelStartTime = new Label()
            {
                Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold),
                Location = new Point(-2, 3),
                Text = program.StartTime.ToString("H:mm")
            };
            labelTimeLength = new Label()
            {
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold),
                Location = new Point(3, 26),
                Text = (program.EndTime - program.StartTime).TotalMinutes.ToString("0") + " perc"
            };
            pictureKorhatar = new PictureBox()
            {
                Image = getAgeLimitPic(),
                Location = new Point(267, 5)
            };

            Controls.Add(labelTitle);
            Controls.Add(labelGenre);
            Controls.Add(labelTimeLength);
            Controls.Add(pictureKorhatar);
            Controls.Add(labelStartTime);

            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(this.pictureKorhatar, TvProgramManager.GetAgeLimitMessage(this.program.AgeLimit));
        }
    }
}
