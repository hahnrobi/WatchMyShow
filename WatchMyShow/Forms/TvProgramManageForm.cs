using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;

namespace WatchMyShow.Forms
{
    public partial class TvProgramManageForm : Form
    {
        private TvProgramManager ProgramManager;
        private ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;

        private event EventHandler<TvProgramReceivedEventArgs> ProgramsReveiced;

        private List<TvProgram> programs;
        private int orderColumn = 2;
        private bool orderAscending = true;

        public TvProgramManageForm()
        {
            InitializeComponent();
            ProgramManager = new TvProgramManager();
            channelSelector.Items.AddRange(ProgramManager.GetTvChannels().ToArray());
            ResetFilters();
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
            if (!orderAscending)
            {
                programs.Reverse();
            }
        }

        public void UpdateTvShowList()
        {
            loadingLabel.Text = "Betöltés...";
            queryLabel.Text = "";
            programList.Enabled = false;
            FilterButton.Enabled = false;
            List<string> selectedChannels = new List<string>();
            foreach (string item in channelSelector.CheckedItems)
            {
                selectedChannels.Add(item);
            }
            ProgramDisplay display = programDisplay;
            if (onlyReserverProgramsCheckBox.Checked)
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
            DoOrderBy(ref programs);
            foreach (TvProgram item in programs)
            {
                programList.Invoke(
                    (Action)(() =>
                    {
                        AddTvProgramToList(item);
                    })
                );
            }
            loadingLabel.Text = "Kész.";
            queryLabel.Text = programList.Items.Count + " műsor listázva";

            if (FilterButton.InvokeRequired)
            {
                FilterButton.Invoke((Action)(() => { FilterButton.Enabled = true; }));
            }
            else
            {
                FilterButton.Enabled = true;
            }
            if (programList.InvokeRequired)
            {
                programList.Invoke((Action)(() => { programList.Enabled = true; }));
            }
            else
            {
                programList.Enabled = true;
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
            if (orderColumn == e.Column)
            {
                orderAscending = !orderAscending;
            }
            else
            {
                orderAscending = true;
            }
            orderColumn = e.Column;
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
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        RandomTvProgramGenerator randomTv = new RandomTvProgramGenerator();
                        randomTv.BulkGenerate(selectedChannels.ToArray(), datePickerStart.Value, datePickerEnd.Value, ofd.FileName);

                        UpdateTvShowList();
                    }
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
            //ProgramManager.ImportTvPrograms("tv.xml");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Fájlok | *.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ProgramManager.ImportTvPrograms(ofd.FileName))
                    {
                        MessageBox.Show("A műsorok importálás sikeresen megtörtént");
                    }
                    else
                    {
                        MessageBox.Show("Hiba történt importálás közben.\nLehet, hogy csak a műsorok egy része, vagy egy műsor sem került importálásra.", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (TvProgramCreateEditException programEx)
                {
                    MessageBox.Show(programEx.Msg);
                }
            }

        }

        private void resetFilterButton_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void exportálásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selectedChannels = new List<string>();
            for (int i = 0; i < channelSelector.Items.Count; i++)
            {
                if (channelSelector.GetItemChecked(i))
                {
                    selectedChannels.Add(channelSelector.Items[i].ToString());
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Fájlok | *.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (ProgramManager.ExportTvPrograms(sfd.FileName, datePickerStart.Value.Date, datePickerEnd.Value.Date, selectedChannels))
                {
                    MessageBox.Show("Mentés sikeresen megtörtént!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("A mentés sikertelen volt.\nLehet, hogy a fájl írásvédett, vagy egy másik folyamat használja.", "Sikertelen mentés", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    while (result != DialogResult.Cancel)
                    {
                        if (ProgramManager.ExportTvPrograms(sfd.FileName, datePickerStart.Value.Date, datePickerEnd.Value.Date, selectedChannels))
                        {
                            result = DialogResult.Cancel;
                        }
                        else
                        {
                            result = MessageBox.Show("A mentés sikertelen volt.\nLehet, hogy a fájl írásvédett, vagy egy másik folyamat használja.", "Sikertelen mentés", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
