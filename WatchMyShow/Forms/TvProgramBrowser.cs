using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;

namespace WatchMyShow.Forms
{
    public partial class TvProgramBrowser : Form
    {
        CalendarPicker cp;
        Room room;
        event EventHandler<TvProgramReceivedEventArgs> ProgramsReveiced;
        public TvProgramBrowser()
        {
            InitializeComponent();
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
                cp.DateChanged += (o, i) => { this.datePicker.Value = i.Date; };
                datePicker.ValueChanged += (o, i) => { cp.Date = datePicker.Value; };
                cp.FormClosed += (o, i) => { dátumVálasztóToolStripMenuItem.Checked = false; };
                cp.Load += (o, i) => { dátumVálasztóToolStripMenuItem.Checked = true; };
                cp.Show();
            }

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
        public void UpdateTvShowList()
        {
            this.loadingLabel.Text = "Betöltés...";
            string channel = channelSelector.Text;
            Console.WriteLine(channel);
            DateTime time = datePicker.Value;
            Task.Run(() =>
            {
                using (TvContext context = new TvContext())
                {
                    var shows = from p in context.Programs
                                where System.Data.Entity.Core.Objects.EntityFunctions.DiffDays(p.StartTime, time) == 0 && p.TvChannel == channel
                                select p;

                    List<TvProgram> programs = new List<TvProgram>();
                    foreach (TvProgram item in shows)
                    {
                        programs.Add(item);
                    }

                    ProgramsReveiced?.Invoke(null, new TvProgramReceivedEventArgs() { Programs = programs });
                }
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
                        ctrl.buttonFoglalas.Click += (o, i) => { this.UpdateTvShowList(); };
                        flowLayoutPanel1.Controls.Add(ctrl);
                        ctrl.SelectedProgramChaned += (o, args) => { this.ChangeChannel(args.Program.TvChannel); };
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
            
            this.loadingLabel.Text = "Kész.";
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

                this.room = rb.Room;
                szobaVálasszonToolStripMenuItem.Text = "Szoba: " + this.room.RoomId;
                UpdateTvShowList();
                Console.WriteLine(room.RoomId);
            }

        }

    }
}
