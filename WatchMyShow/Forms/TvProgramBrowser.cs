using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;

namespace WatchMyShow.Forms
{
    public partial class TvProgramBrowser : Form
    {
        private CalendarPicker cp;
        private Room room;
        private TvProgramManager ProgramManager;
        private ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;

        private event EventHandler<TvProgramReceivedEventArgs> ProgramsReveiced;
        public TvProgramBrowser()
        {
            InitializeComponent();
            ProgramManager = new TvProgramManager();
            channelSelector.SelectedIndexChanged += UpdateChannelChangeButtons;
            buttonChannelBackward.Click += (s, args) => { ChangeChannel(-1); };
            buttonChannelForward.Click += (s, args) => { ChangeChannel(1); };

            datePicker.ValueChanged += UpdateCalendarChangeButtons;
            buttonCalendarForward.Click += (s, args) => { ChangeDate(1); };
            buttonCalendarBackward.Click += (s, args) => { ChangeDate(-1); };

            foreach (ToolStripMenuItem item in korhatárToolStripMenuItem.DropDownItems)
            {
                item.Click += (sender, args) => { UpdateTvShowList(); };
            }

            reserveProgramDisplayMenuItem.Click += UpdateProgramDisplay;
            freeProgramDisplayMenuItem.Click += UpdateProgramDisplay;

        }

        private void TvProgramBrowser_Load(object sender, EventArgs e)
        {

            using (TvContext context = new TvContext())
            {
                var getChannels = from program in context.Programs
                                  group program by program.TvChannel into newGroup
                                  orderby newGroup.Key
                                  select newGroup;
                foreach (var channels in getChannels)
                {
                    channelSelector.Items.Add(channels.Key);
                }
            }
            ProgramsReveiced += OnTvProgramsReveived;
            datePicker.ValueChanged += (o, i) => { UpdateTvShowList(); };
        }


        private void dátumVálasztóToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dátumVálasztóToolStripMenuItem.Checked)
            {
                cp.Close();
            }
            else
            {
                cp = new CalendarPicker(datePicker.Value);
                cp.DateChanged += (o, i) => { datePicker.Value = i.Date; };
                datePicker.ValueChanged += (o, i) => { cp.Date = datePicker.Value; };
                cp.FormClosed += (o, i) => { dátumVálasztóToolStripMenuItem.Checked = false; };
                cp.Load += (o, i) => { dátumVálasztóToolStripMenuItem.Checked = true; };
                cp.Show();
            }

        }
        private void UpdateChannelChangeButtons(object sender, EventArgs e)
        {
            #region GombUpdate
            int currrentChannel = channelSelector.SelectedIndex;
            if (currrentChannel == 0)
            {
                buttonChannelBackward.Enabled = false;
            }
            else
            {
                buttonChannelBackward.Enabled = true;
            }
            if (currrentChannel + 1 >= channelSelector.Items.Count)
            {
                buttonChannelForward.Enabled = false;
            }
            else
            {
                buttonChannelForward.Enabled = true;
            }
            #endregion
        }
        private void ChangeDate(int days)
        {
            DateTime now = datePicker.Value;
            DateTime min = DateTime.MinValue;
            DateTime max = DateTime.MaxValue;

            if (!(now.AddDays(days) > max || now.AddDays(2) < min))
            {
                datePicker.Value = now.AddDays(days);
            }
        }
        private void UpdateCalendarChangeButtons(object sender, EventArgs e)
        {
            DateTime now = datePicker.Value;
            DateTime max = datePicker.MaxDate;
            DateTime min = datePicker.MinDate;
            if (now.AddDays(-1) <= min)
            {
                buttonCalendarBackward.Enabled = false;
            }
            else
            {
                buttonCalendarBackward.Enabled = true;
            }
            if (now.AddDays(1) >= max)
            {
                buttonCalendarForward.Enabled = false;
            }
            else
            {
                buttonCalendarForward.Enabled = true;
            }
        }
        private void UpdateProgramDisplay(object sender, EventArgs e)
        {
            if (reserveProgramDisplayMenuItem.Checked)
            {
                programDisplay = programDisplay | ProgramDisplay.OnlyReserved;
            }
            else
            {
                programDisplay = programDisplay & ~ProgramDisplay.OnlyReserved;
            }
            if (freeProgramDisplayMenuItem.Checked)
            {
                programDisplay = programDisplay | ProgramDisplay.OnlyFree;
            }
            else
            {
                programDisplay = programDisplay & ~ProgramDisplay.OnlyFree;
            }
            UpdateTvShowList();
        }
        private void ChangeChannel(string channel)
        {
            int i = 0;
            while (channel != (string)channelSelector.Items[i] && i < channelSelector.Items.Count)
            {
                i++;
            }
            if (i < channelSelector.Items.Count)
            {
                channelSelector.SelectedIndex = i;
            }
        }
        private void ChangeChannel(int jump)
        {
            int channels = channelSelector.Items.Count;
            int currrentChannel = channelSelector.SelectedIndex;
            if (jump != 0)
            {
                if (!(currrentChannel + jump >= channels || currrentChannel + jump < 0))
                {
                    channelSelector.SelectedIndex = currrentChannel + jump;
                    currrentChannel += jump;
                }
            }

        }
        private AgeLimit FetchAgeLimitMenuSelect()
        {
            AgeLimit ageLimit = new AgeLimit();
            if (korhatarNelkulMenuItem.Checked)
            {
                ageLimit = ageLimit | AgeLimit.NoLimit;
            }
            if (korhatar6MenuItem.Checked)
            {
                ageLimit = ageLimit | AgeLimit.Above6;
            }
            if (korhatar12MenuItem.Checked)
            {
                ageLimit = ageLimit | AgeLimit.Above12;
            }
            if (korhatar16MenuItem.Checked)
            {
                ageLimit = ageLimit | AgeLimit.Above16;
            }
            if (korhatar18MenuItem.Checked)
            {
                ageLimit = ageLimit | AgeLimit.Above18;
            }
            return ageLimit;
        }

        public void UpdateTvShowList()
        {
            loadingLabel.Text = "Betöltés...";
            string channel = channelSelector.Text;
            DateTime time = datePicker.Value;
            Task.Run(() =>
            {
                //AgeLimit ageLimit = FetchAgeLimitMenuSelect();
                //var shows = from p in context.Programs
                //            where 
                //            System.Data.Entity.Core.Objects.EntityFunctions.DiffDays(p.StartTime, time) == 0 
                //            &&
                //            p.TvChannel == channel
                //            &&
                //            ((p.AgeLimit & ageLimit) != 0)
                //            select p;

                //List<TvProgram> programs = new List<TvProgram>();
                //foreach (TvProgram item in shows)
                //{
                //    programs.Add(item);
                //}
                List<TvProgram> programs = ProgramManager.RetrieveTvPrograms(time, channel, programDisplay, FetchAgeLimitMenuSelect());
                ProgramsReveiced?.Invoke(null, new TvProgramReceivedEventArgs() { Programs = programs });
            });
        }
        private void TvProgramBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cp != null)
            {
                cp.Close();
            }
        }
        private void OnTvProgramsReveived(object sender, TvProgramReceivedEventArgs e)
        {
            flowLayoutPanel1.Invoke((Action)(() =>
            {
                flowLayoutPanel1.Controls.Clear();
            }));
            foreach (TvProgram item in e.Programs)
            {
                flowLayoutPanel1.Invoke(
                    (Action)(() =>
                    {
                        TvProgramControl ctrl = new TvProgramControl(item, room);
                        ctrl.buttonFoglalas.Click += (o, i) => { UpdateTvShowList(); };
                        flowLayoutPanel1.Controls.Add(ctrl);
                        ctrl.SelectedProgramChaned += (o, args) => { ChangeChannel(args.Program.TvChannel); };
                    })
                );
            }
            if (e.Programs.Count == 0)
            {
                flowLayoutPanel1.Invoke(
                    (Action)(() =>
                    {
                        flowLayoutPanel1.Controls.Add(new Label() { Text = "Nem található műsor", Size = new Size(400, 30) });
                    })
                );
            }
            loadingLabel.Text = "Kész.";
        }
        private void channelSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTvShowList();
        }

        private void szobaVálasszonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomBrowser rb = new RoomBrowser();
            if (rb.ShowDialog() == DialogResult.OK)
            {

                room = rb.Room;
                szobaVálasszonToolStripMenuItem.Text = "Szoba: " + room.RoomId;
                UpdateTvShowList();
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
}
