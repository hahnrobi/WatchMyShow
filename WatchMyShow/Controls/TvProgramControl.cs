using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;

namespace WatchMyShow
{
    internal class TvProgramControl : Panel
    {

        private Label labelTitle;
        private Label labelGenre;
        private Label labelStartTime;
        private Label labelTimeLength;
        private Label labelStatus;
        private PictureBox pictureKorhatar;
        public Button buttonFoglalas;
        private TvProgram program;
        private Room room;
        private ProgressBar elapsedTimeProgress;

        public EventHandler<ProgramChangeEventArgs> SelectedProgramChaned;

        public TvProgramControl(TvProgram program)
        {
            this.program = program;
            room = program.Reserved;
            InitializeComponent();
        }
        public TvProgramControl(TvProgram program, Room room)
        {
            this.room = room;
            this.program = program;
            InitializeComponent();
        }
        private void CheckProgramElapsedTime()
        {
            if (program.StartTime.TimeOfDay <= DateTime.Now.TimeOfDay && program.EndTime.TimeOfDay >= DateTime.Now.TimeOfDay)
            {
                TimeSpan fullTime = program.EndTime.TimeOfDay - program.StartTime.TimeOfDay;
                TimeSpan elapsedTime = DateTime.Now.TimeOfDay - program.StartTime.TimeOfDay;
                elapsedTimeProgress.Maximum = (int)fullTime.TotalMinutes;
                elapsedTimeProgress.Minimum = 0;
                elapsedTimeProgress.Value = (int)elapsedTime.TotalMinutes;
                elapsedTimeProgress.Visible = true;

            }
            else
            {
                elapsedTimeProgress.Visible = false;
            }
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
                AutoSize = true,
                MaximumSize = new Size(220, 21),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                Text = program.Title
            };
            labelGenre = new Label()
            {
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular),
                Location = new Point(56, 28),
                Size = new Size(156, 30),
                AutoSize = true,
                MaximumSize = new Size(156, 70),
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
            labelStatus = new Label()
            {
                Location = new Point(200, 60),
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold),
                Visible = false
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
                BackColor = Control.DefaultBackColor,
                Visible = false
            };
            elapsedTimeProgress = new ProgressBar()
            {
                Visible = false,
                Location = new Point(0, 0),
                Size = new Size(303, 5),
                BackColor = Color.MediumVioletRed,

            };
            CheckProgramElapsedTime();

            //FOGLALÁS BEGINS
            using (TvContext context = new TvContext())
            {
                //Olyan műsorok lekérése, amelyek ugyanabban az időpontban vannak műsoron, mint ebbe a Controlba kapott műsor.
                //Olyan műsor ami foglalva van, hamarabb, vagy ugyanakkor kezdődik mint a kiválasztott és később van vége, mint ahogy a kiválasztott elkezdődne.
                var shows = from p in context.Programs
                            where
                                p.Reserved != null &&
                                p.StartTime <= program.StartTime &&
                                p.EndTime > program.StartTime
                            select p;
                //Látható legyen a foglalás gomb. Minden más többi esetben csak eltüntetve lesz.
                if (room != null)
                {
                    if (program.StartTime >= DateTime.Now || program.StartTime <= DateTime.Now && program.EndTime >= DateTime.Now)
                    {
                        buttonFoglalas.Visible = true;
                    }
                }
                //Ha van olyan műsor amivel átfedésben van
                if (shows.Count() > 0)
                {
                    //Ha ütközik másik programmal, megnézzük, hogy önmaga is a foglalt műsorok között van.
                    bool isSelf = (from p in shows
                                   where p.ProgramId == program.ProgramId
                                   select p)
                                     .Count() > 0;

                    buttonFoglalas.Visible = false;

                    //Ha önmaga az éppen ütköző foglalt műsorok között van, akkor tudatjuk a felhasználóval, ez van az adott időpotban lefoglalva.
                    if (isSelf)
                    {
                        labelStatus.Text = "Lefoglalt";
                        System.Windows.Forms.ToolTip ttt = new System.Windows.Forms.ToolTip();
                        ttt.SetToolTip(labelStatus, "Ez a műsor már le van foglalva, így nézhető lesz.\nLefoglaló szoba: " + program.ReservedRoomId);
                    }
                    else
                    {
                        //Ebben az esetben a műsor nem foglalható le, mert ekkor másik lefoglalt műsor fut. Hogy a felhasználó tudja, hogy mi, 
                        //jobb kattintásra context menüben megjelenik a műsor, rákattintva ahhoz a tv csatornához ugrik a program.
                        var reservedShows = from p in shows
                                            where p.ProgramId != program.ProgramId
                                            select p;

                        ContextMenuStrip cm = new ContextMenuStrip() { RenderMode = ToolStripRenderMode.System };
                        //Alap foglalt műsor szöveg és egy divider.
                        ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = "Foglalt műsor", Enabled = false };
                        cm.Items.Add(menuItem);
                        cm.Items.Add(new ToolStripSeparator());

                        //Ütköző műsor berakása a listába.
                        foreach (var show in reservedShows)
                        {
                            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem()
                            {
                                Text = String.Format(
                                    "{0} {1}:{2}-{3}:{4} ({5})",
                                    show.Title, //0
                                    show.StartTime.Hour, //1
                                    show.StartTime.Minute, //2
                                    show.EndTime.Hour, //3
                                    show.EndTime.Minute, //4
                                    show.TvChannel //5
                                )
                            };
                            //Kattintásra elsütjük a SelectedProgramChanged eseményt, ami megváltoztatja a megjelenített csatornát
                            toolStripMenuItem.Click += (i, o) => { SelectedProgramChaned?.Invoke(this, new ProgramChangeEventArgs() { Program = show }); };
                            //És hozzá is adjuk a menühöz az elemet.
                            cm.Items.Add(toolStripMenuItem);
                        }
                        labelStatus.ContextMenuStrip = cm;
                        //Kis tooltip, hogy érthető legyen miért van kint a felirat.
                        System.Windows.Forms.ToolTip ttt = new System.Windows.Forms.ToolTip();
                        ttt.SetToolTip(labelStatus, "Ebben az időpontban egy másik lefoglalt műsorral van átfedésben.\nJobb kattintással többet megtudhat.");

                        labelStatus.Text = "Nem foglalható";
                    }
                    labelStatus.ForeColor = Color.Gray;
                    labelStatus.Visible = true;
                }
                else
                {
                    //Ha pedig nincs foglalt program ennek az időpontjában, akkor a gombhoz hozzárendeljük a foglalást megvalósító metódust.
                    buttonFoglalas.Click += (o, i) => { TvProgramManager.ReserveTvProgram(program, room); };
                }
                //Itt pedig felülírjuk a dolgokat annyival, hogyha az adott műsor saját szoba foglalása.
                if (context.Rooms.Find(program.ReservedRoomId) != null)
                {
                    if (room != null && context.Rooms.Find(program.ReservedRoomId).RoomId == room.RoomId)
                    {
                        labelStatus.ForeColor = Color.Green;
                        labelStatus.Text = "Saját foglalás";
                        labelStatus.Visible = true;
                    }
                    buttonFoglalas.Visible = false;
                }
            }


            //FOGLALÁS ENDS

            Controls.Add(labelTitle);
            Controls.Add(labelGenre);
            Controls.Add(labelTimeLength);
            Controls.Add(labelStatus);
            Controls.Add(pictureKorhatar);
            Controls.Add(labelStartTime);
            Controls.Add(buttonFoglalas);
            Controls.Add(elapsedTimeProgress);
            elapsedTimeProgress.BringToFront();

            Timer timer = new Timer() { Interval = 5000 };
            timer.Tick += (obj, args) => { CheckProgramElapsedTime(); };
            timer.Start();


            System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
            tt.SetToolTip(pictureKorhatar, TvProgramManager.GetAgeLimitMessage(program.AgeLimit));
        }
    }
}
