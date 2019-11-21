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
        TvProgramManager ProgramManager;
        ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;
        event EventHandler<TvProgramReceivedEventArgs> ProgramsReveiced;
        List<TvProgram> programs;
        int orderColumn = 2;
        bool orderAscending = true;

        public TvProgramManageForm()
        {
            InitializeComponent();
            ProgramManager = new TvProgramManager();
            channelSelector.Items.AddRange(ProgramManager.GetTvChannels().ToArray());
            this.ResetFilters();
            ProgramsReveiced += OnTvProgramsReveived;
            programs = new List<TvProgram>();
        }

        private void TvProgramManageForm_Load(object sender, EventArgs e)
        {

        }
        private void DoOrderBy(ref List<TvProgram> programs)
        {
            switch (orderColumn)
            {
                case 0:
                    programs = programs.OrderBy(p => p.Title).ToList();
                    break;
                case 1:
                    programs = programs.OrderBy(p => p.TvChannel).ToList();
                    break;
                case 2:
                    programs = programs.OrderBy(p => p.StartTime).ToList();
                    break;
                case 6:
                    programs = programs.OrderBy(p => p.AgeLimit).ToList();
                    break;
                case 7:
                    programs = programs.OrderBy(p => p.ReservedRoomId).ToList();
                    break;
                default:

                    break;
            }
            if (!this.orderAscending)
            {
                programs.Reverse();
            }
        }

        public void UpdateTvShowList()
        {
            this.loadingLabel.Text = "Betöltés...";
            this.programList.Enabled = false;
            this.FilterButton.Enabled = false;
            List<string> selectedChannels = new List<string>();
            foreach (string item in channelSelector.CheckedItems)
            {
                selectedChannels.Add(item);
            }
            ProgramDisplay display = this.programDisplay;
            if(onlyReserverProgramsCheckBox.Checked)
            {
                display = ProgramDisplay.OnlyReserved;
            }
            string channel = channelSelector.Text;
            DateTime startTime = datePickerStart.Value;
            DateTime endTime = datePickerEnd.Value;
            Tuple<DateTime, DateTime> dateRange = new Tuple<DateTime, DateTime>(startTime, endTime);
            Task.Run(() =>
            {
                List<TvProgram> programs = ProgramManager.RetrieveTvPrograms(dateRange, selectedChannels, display, TvProgramManager.AllAgeLimit());
                ProgramsReveiced?.Invoke(null, new TvProgramReceivedEventArgs() { Programs = programs });
            });
        }
        private void OnTvProgramsReveived(object sender, TvProgramReceivedEventArgs e)
        {
            programList.Invoke((Action)(() =>
            {
                programList.Items.Clear();
            }));
            programs = e.Programs;
            this.DoOrderBy(ref programs);
            foreach (TvProgram item in programs)
            {
                programList.Invoke(
                    (Action)(() =>
                    {
                        AddTvProgramToList(item);
                    })
                );
            }
            this.loadingLabel.Text = "Kész.";

            if (this.FilterButton.InvokeRequired)
            {
                this.FilterButton.Invoke((Action)(() => { this.FilterButton.Enabled = true; }));
            }
            else
            {
                this.FilterButton.Enabled = true;
            }
            if (this.programList.InvokeRequired)
            {
                this.programList.Invoke((Action)(() => { this.programList.Enabled = true; }));
            }
            else
            {
                this.programList.Enabled = true;
            }

        }
        private void ResetFilters()
        {
            Tuple<DateTime, DateTime> firstLastDate = ProgramManager.GetFirstLastProgramDate();
            datePickerStart.Value = firstLastDate.Item1;
            datePickerEnd.Value = firstLastDate.Item2;
            onlyReserverProgramsCheckBox.Checked = false;
            for (int i = 0; i < channelSelector.Items.Count; i++)
            {
                channelSelector.SetItemCheckState(i, CheckState.Checked);
            }
        }
        private void AddTvProgramToList(TvProgram program)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = program;
            item.SubItems.Add(program.TvChannel);
            item.SubItems.Add(program.StartTime.ToString("yyyy.MM.dd"));
            item.SubItems.Add(program.StartTime.ToString("HH:mm:ss"));
            item.SubItems.Add(program.AgeLimit.ToString());
            item.SubItems.Add(program.EndTime.ToString("HH:mm:ss"));
            if (program.ReservedRoomId != null)
            {
                item.SubItems.Add(program.ReservedRoomId.ToString());
            }

            item.Text = program.Title;
            programList.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTvShowList();
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (datePickerEnd.Value < datePickerStart.Value)
            {
                datePickerStart.Value = datePickerEnd.Value;
            }
        }

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (datePickerStart.Value > datePickerEnd.Value)
            {
                datePickerEnd.Value = datePickerStart.Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void programList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void programList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.orderColumn == e.Column)
            {
                this.orderAscending = !this.orderAscending;
            }
            else
            {
                this.orderAscending = true;
            }
            this.orderColumn = e.Column;
            UpdateTvShowList();
        }

        private void szerkesztésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in programList.SelectedItems)
            {
                TvProgramEditor tvProgramEditor = new TvProgramEditor(item.Tag as TvProgram);
                if (tvProgramEditor.ShowDialog() == DialogResult.OK)
                {
                    UpdateTvShowList();
                }
            }
        }

        private void programList_DoubleClick(object sender, EventArgs e)
        {
            szerkesztésToolStripMenuItem.PerformClick();
        }

        private void létrehozásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TvProgramEditor tvProgramEditor = new TvProgramEditor();
            if (tvProgramEditor.ShowDialog() == DialogResult.OK)
            {
                UpdateTvShowList();
            }
        }

        private void tVCsatornaListaFrissítéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            channelSelector.Items.Clear();
            channelSelector.Items.AddRange(ProgramManager.GetTvChannels().ToArray());
            for (int i = 0; i < channelSelector.Items.Count; i++)
            {
                channelSelector.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (programList.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Biztosan törli a kiválasztott műsort?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in programList.SelectedItems)
                    {
                        ProgramManager.DeleteProgram(item.Tag as TvProgram);
                        UpdateTvShowList();
                    }
                }
            }

        }

        private void műsorokVéletlenszerűGenerálásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan szeretnél generálni új műsorokat?\nA program a szűrésnél beállított időintervallumra és kiválasztott csatornákra fog véletlenszerű műsorokat generálni.", "Generálás", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    List<string> selectedChannels = new List<string>();
                    for (int i = 0; i < channelSelector.Items.Count; i++)
                    {
                        if (channelSelector.GetItemChecked(i))
                        {
                            selectedChannels.Add(channelSelector.Items[i].ToString());
                        }
                    }
                    RandomTvProgramGenerator randomTv = new RandomTvProgramGenerator();
                    randomTv.BulkGenerate(selectedChannels.ToArray(), datePickerStart.Value, datePickerEnd.Value.AddDays(1));
                    UpdateTvShowList();
                }
                catch (TvProgramCreateEditException ex)
                {
                    MessageBox.Show(ex.Msg);
                }
            }
        }


        private void programList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                törlésToolStripMenuItem.PerformClick();
            }
        }

        private void xMLFájlbólToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramManager.ImportTvPrograms("tv.xml");
        }

        private void resetFilterButton_Click(object sender, EventArgs e)
        {

        }
    }
}
