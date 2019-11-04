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
        public Button buttonFoglalas;
        private TvProgram program;
        private Room room;
                
        public TvProgramControl(TvProgram program)
        {
            this.program = program;
            InitializeComponent();
        }
        public TvProgramControl(TvProgram program, Room room)
        {
            this.room = room;
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
                Text = program.StartTime.ToString("HH:mm")
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
                Location = new Point(267, 5),
                Size = new Size(32, 32)
            };
            buttonFoglalas = new Button()
            {
                Text = "Foglalás",
                Location = new Point(223, 52),
                BackColor = Color.LemonChiffon,
            };

            if (room != null)
            {

                using (TvContext context = new TvContext()) 
                {
                    var shows = from p in context.Programs
                                where 
                                    p.Reserved != null && 
                                    p.StartTime <= program.StartTime && 
                                    p.EndTime > program.StartTime
                                select p;

                    buttonFoglalas.Visible = true;
                    if (shows.Count() > 0)
                    {
                        buttonFoglalas.Enabled = false;
                        buttonFoglalas.Text = "Nem foglalható.";
                        buttonFoglalas.BackColor = Color.Gray;
                        buttonFoglalas.Size = new Size(123, 23);
                    }
                    else {
                        buttonFoglalas.Click += (o, i) => { TvProgramManager.ReserveTvProgram(program, room); };
                    }
                    
                }
                if (program.Reserved != null)
                {
                    if (program.Reserved.RoomId == room.RoomId)
                    {
                        buttonFoglalas.BackColor = Color.Green;
                        buttonFoglalas.Text = "Saját foglalás";
                        buttonFoglalas.Size = new Size(123, 23);
                    }
                    buttonFoglalas.Enabled = false;
                }
            }
            else
            {
                buttonFoglalas.Visible = false;
            }

            Controls.Add(labelTitle);
            Controls.Add(labelGenre);
            Controls.Add(labelTimeLength);
            Controls.Add(pictureKorhatar);
            Controls.Add(labelStartTime);
            Controls.Add(buttonFoglalas);

            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(this.pictureKorhatar, TvProgramManager.GetAgeLimitMessage(this.program.AgeLimit));
        }
    }
}
