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
    public partial class TvProgramManageForm : Form
    {
        CalendarPicker cp;
        Room room;
        TvProgramManager ProgramManager;
        ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;
        event EventHandler<TvProgramReceivedEventArgs> ProgramsReveiced;

        public TvProgramManageForm()
        {
            InitializeComponent();
            ProgramManager = new TvProgramManager();
            channelSelector.Items.AddRange(ProgramManager.GetTvChannels().ToArray());
            ProgramsReveiced += OnTvProgramsReveived;
        }

        private void TvProgramManageForm_Load(object sender, EventArgs e)
        {

        }


        public void UpdateTvShowList()
        {
            string channel = channelSelector.Text;
            DateTime time = datePicker.Value;
            Task.Run(() =>
            {
                List<TvProgram> programs = ProgramManager.RetrieveTvPrograms(time, channelSelector, programDisplay, TvProgramManager.AllAgeLimit());
                ProgramsReveiced?.Invoke(null, new TvProgramReceivedEventArgs() { Programs = programs });
            });
        }
        private void OnTvProgramsReveived(object sender, TvProgramReceivedEventArgs e)
        {
            programList.Invoke((Action)(() =>
            {
                programList.Items.Clear();
            }));
            foreach (TvProgram item in e.Programs)
            {
                programList.Invoke(
                    (Action)(() =>
                    {
                        AddTvProgramToList(item);
                    })
                );
            }

        }

        private void AddTvProgramToList(TvProgram program)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(program.TvChannel);
            item.SubItems.Add(program.StartTime.ToString("yyyy.MM.dd"));
            item.SubItems.Add(program.StartTime.ToString("HH:mm:ss"));
            item.SubItems.Add(program.EndTime.ToString("HH:mm:ss"));
            item.SubItems.Add(program.AgeLimit.ToString());
            item.Text = program.Title;
            programList.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTvShowList();
        }
    }
}
