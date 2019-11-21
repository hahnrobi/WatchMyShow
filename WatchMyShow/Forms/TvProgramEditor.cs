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

namespace WatchMyShow.Forms
{
    public partial class TvProgramEditor : Form
    {
        private TvProgram tvProgram;
        TvProgramManager manager;

        public TvProgram TvProgram
        {
            get { return tvProgram; }
            private set { tvProgram = value; }
        }

        public TvProgramEditor()
        {
            InitializeComponent();
            manager = new TvProgramManager();
            tvProgram = new TvProgram();
            programTvChannelTextBox.Items.AddRange(manager.GetTvChannels().ToArray());
            
            this.tabControl1.TabPages.RemoveAt(this.tabControl1.TabPages.Count - 1);
            //Genre Selector
            foreach (string genre in TvProgramManager.GetAllGenresAsString())
            {
                this.programGenresCheckedListBox.Items.Add(genre);
            }

            //Age Limit Selector
            this.programAgeLimitComboBox.Items.AddRange(TvProgramManager.GetAllAgeLimitMessages());
            this.programAgeLimitComboBox.SelectedIndex = this.programAgeLimitComboBox.Items.Count - 1;
            setAgeLimitListBox(AgeLimit.Above18);

            this.programScreenTimeLabel.Text = $"Játékidő: {calcScreenTime()} perc";
        }
        public TvProgramEditor(TvProgram importProgram)
        {
            InitializeComponent();
            manager = new TvProgramManager();
            programTvChannelTextBox.Items.AddRange(manager.GetTvChannels().ToArray());
            this.tvProgram = importProgram;
            this.programTitleTextBox.Text = tvProgram.Title;
            this.programTvChannelTextBox.Text = tvProgram.TvChannel;
            this.programDatePicker.Value = tvProgram.StartTime.Date;
            this.programStartPicker.Value = tvProgram.StartTime;
            this.programEndPicker.Value = tvProgram.EndTime;
            this.programGenresCheckedListBox.Items.Clear();

            //Genre Selector
            foreach (string genre in TvProgramManager.GetAllGenresAsString())
            {
                this.programGenresCheckedListBox.Items.Add(genre);
            }
            getCheckedGenres(tvProgram.Genre);

            //Age Limit Selector
            this.programAgeLimitComboBox.Items.AddRange(TvProgramManager.GetAllAgeLimitMessages());
            this.programAgeLimitComboBox.SelectedIndex = this.programAgeLimitComboBox.Items.Count - 1;
            setAgeLimitListBox(tvProgram.AgeLimit);

            this.programScreenTimeLabel.Text = $"Játékidő: {calcScreenTime()} perc";

            if(this.tvProgram.ReservedRoomId != null)
            {
                this.programReservedLabel.Text = "Ezt a műsort az alábbi szoba foglalta le: " + this.tvProgram.ReservedRoomId;
            }
            else
            {
                this.tabControl1.TabPages.RemoveAt(this.tabControl1.TabPages.Count - 1);
            }
        }
        private int calcGenre()
        {
            int value = 0;
            for (int i = 0; i < programGenresCheckedListBox.Items.Count; i++)
            {
                if (programGenresCheckedListBox.GetItemChecked(i))
                {
                    value = value + (int)Math.Pow(2, i);
                }
            }
            return value;
        }
        private int calcAgeLimit()
        {
            return (int)Math.Pow(2, programAgeLimitComboBox.SelectedIndex);
        }
        private void getCheckedGenres(TvProgramGenre genre)
        {
            for (int i = 0; i < programGenresCheckedListBox.Items.Count; i++)
            {
                if (((TvProgramGenre)Math.Pow(2, i) & genre) != 0)
                {
                    programGenresCheckedListBox.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }
        private void setAgeLimitListBox(AgeLimit limit)
        {
            for (int i = 0; i < programAgeLimitComboBox.Items.Count; i++)
            {
                if (((AgeLimit)Math.Pow(2, i) & limit) != 0)
                {
                    programAgeLimitComboBox.SelectedIndex = i;
                }
            }
        }
        private void TvProgramEditor_Load(object sender, EventArgs e)
        {

        }
        private void GenerateNewProgram()
        {
            this.tvProgram.Title = this.programTitleTextBox.Text;
            this.tvProgram.TvChannel = this.programTvChannelTextBox.Text;
            this.tvProgram.Genre = (TvProgramGenre)calcGenre();
            this.tvProgram.AgeLimit = (AgeLimit)calcAgeLimit();
            DateTime picker = this.programDatePicker.Value;
            DateTime start = this.programStartPicker.Value;
            DateTime end = this.programEndPicker.Value;
            Console.WriteLine(tvProgram.StartTime.ToString());
            Console.WriteLine(tvProgram.EndTime.ToString());
            this.tvProgram.StartTime = new DateTime(picker.Year, picker.Month, picker.Day, start.Hour, start.Minute, 0);
            this.tvProgram.EndTime = new DateTime(picker.Year, picker.Month, picker.Day, end.Hour, end.Minute, 0);

            Console.WriteLine("NEW TIME:");
            Console.WriteLine(tvProgram.StartTime.ToString());
            Console.WriteLine(tvProgram.EndTime.ToString());
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            GenerateNewProgram();
            
            try
            {
                manager.AddTvProgram(this.tvProgram);
                MessageBox.Show("A mentés sikeresen megtörtént.\nA frissített műsor új szűrés után jelenik csak meg.", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }catch (TvProgramCreateEditException ex)
            {
                MessageBox.Show(ex.Msg, "Szerkesztési hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ismeretlen hiba történt");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
        }
        private int calcScreenTime()
        {
            int time = 0;
            TimeSpan t = programEndPicker.Value - programStartPicker.Value;
            time = (int)Math.Floor(t.TotalMinutes);
            return time;
        }
        private void programStartPicker_ValueChanged(object sender, EventArgs e)
        {
            if(programStartPicker.Value > programEndPicker.Value)
            {
                programEndPicker.Value = programStartPicker.Value.AddMinutes(1);
            }
            this.programScreenTimeLabel.Text = $"Játékidő: {calcScreenTime()} perc";
        }

        private void programEndPicker_ValueChanged(object sender, EventArgs e)
        {
            if (programStartPicker.Value > programEndPicker.Value)
            {
                programStartPicker.Value = programEndPicker.Value;
            }
            this.programScreenTimeLabel.Text = $"Játékidő: {calcScreenTime()} perc";
        }

        private void programDeleteReserveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törli a foglalást", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                manager.DeleteReservation(tvProgram);
                MessageBox.Show("Foglalás törlése megtörtént");
                this.Close();
            }
        }
    }
}
