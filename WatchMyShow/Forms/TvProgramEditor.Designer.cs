namespace WatchMyShow.Forms
{
    partial class TvProgramEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.programAgeLimitComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.programGenresCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.programTitleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.programStartPicker = new System.Windows.Forms.DateTimePicker();
            this.programDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.programEndPicker = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.programReservedLabel = new System.Windows.Forms.Label();
            this.programDeleteReserveButton = new System.Windows.Forms.Button();
            this.programScreenTimeLabel = new System.Windows.Forms.Label();
            this.programTvChannelTextBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(357, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.programTvChannelTextBox);
            this.tabPage1.Controls.Add(this.programAgeLimitComboBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.programGenresCheckedListBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.programTitleTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(349, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alapadatok";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.programScreenTimeLabel);
            this.tabPage2.Controls.Add(this.programEndPicker);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.programStartPicker);
            this.tabPage2.Controls.Add(this.programDatePicker);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(349, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Időpontok";
            // 
            // programAgeLimitComboBox
            // 
            this.programAgeLimitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programAgeLimitComboBox.FormattingEnabled = true;
            this.programAgeLimitComboBox.Location = new System.Drawing.Point(21, 308);
            this.programAgeLimitComboBox.Name = "programAgeLimitComboBox";
            this.programAgeLimitComboBox.Size = new System.Drawing.Size(299, 21);
            this.programAgeLimitComboBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Korhatár";
            // 
            // programGenresCheckedListBox
            // 
            this.programGenresCheckedListBox.FormattingEnabled = true;
            this.programGenresCheckedListBox.Location = new System.Drawing.Point(147, 70);
            this.programGenresCheckedListBox.Name = "programGenresCheckedListBox";
            this.programGenresCheckedListBox.Size = new System.Drawing.Size(173, 214);
            this.programGenresCheckedListBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Műfaj";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sugárzó TV csatorna";
            // 
            // programTitleTextBox
            // 
            this.programTitleTextBox.Location = new System.Drawing.Point(147, 16);
            this.programTitleTextBox.Name = "programTitleTextBox";
            this.programTitleTextBox.Size = new System.Drawing.Size(173, 20);
            this.programTitleTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cím";
            // 
            // programStartPicker
            // 
            this.programStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.programStartPicker.Location = new System.Drawing.Point(68, 48);
            this.programStartPicker.Name = "programStartPicker";
            this.programStartPicker.ShowUpDown = true;
            this.programStartPicker.Size = new System.Drawing.Size(107, 20);
            this.programStartPicker.TabIndex = 5;
            this.programStartPicker.ValueChanged += new System.EventHandler(this.programStartPicker_ValueChanged);
            // 
            // programDatePicker
            // 
            this.programDatePicker.Location = new System.Drawing.Point(57, 22);
            this.programDatePicker.Name = "programDatePicker";
            this.programDatePicker.Size = new System.Drawing.Size(200, 20);
            this.programDatePicker.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Dátum:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kezdés";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Befejezés";
            // 
            // programEndPicker
            // 
            this.programEndPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.programEndPicker.Location = new System.Drawing.Point(68, 74);
            this.programEndPicker.Name = "programEndPicker";
            this.programEndPicker.ShowUpDown = true;
            this.programEndPicker.Size = new System.Drawing.Size(107, 20);
            this.programEndPicker.TabIndex = 8;
            this.programEndPicker.ValueChanged += new System.EventHandler(this.programEndPicker_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.programDeleteReserveButton);
            this.tabPage3.Controls.Add(this.programReservedLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(349, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Foglalás";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(268, 428);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "&Mentés";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // programReservedLabel
            // 
            this.programReservedLabel.AutoSize = true;
            this.programReservedLabel.Location = new System.Drawing.Point(7, 7);
            this.programReservedLabel.Name = "programReservedLabel";
            this.programReservedLabel.Size = new System.Drawing.Size(209, 13);
            this.programReservedLabel.TabIndex = 0;
            this.programReservedLabel.Text = "Ezt a műsort a következő szoba foglalta le:";
            // 
            // programDeleteReserveButton
            // 
            this.programDeleteReserveButton.Location = new System.Drawing.Point(10, 23);
            this.programDeleteReserveButton.Name = "programDeleteReserveButton";
            this.programDeleteReserveButton.Size = new System.Drawing.Size(111, 23);
            this.programDeleteReserveButton.TabIndex = 1;
            this.programDeleteReserveButton.Text = "Foglalás törlése";
            this.programDeleteReserveButton.UseVisualStyleBackColor = true;
            this.programDeleteReserveButton.Click += new System.EventHandler(this.programDeleteReserveButton_Click);
            // 
            // programScreenTimeLabel
            // 
            this.programScreenTimeLabel.AutoSize = true;
            this.programScreenTimeLabel.Location = new System.Drawing.Point(8, 104);
            this.programScreenTimeLabel.Name = "programScreenTimeLabel";
            this.programScreenTimeLabel.Size = new System.Drawing.Size(94, 13);
            this.programScreenTimeLabel.TabIndex = 9;
            this.programScreenTimeLabel.Text = "Játékidő: <x> perc";
            // 
            // programTvChannelTextBox
            // 
            this.programTvChannelTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.programTvChannelTextBox.FormattingEnabled = true;
            this.programTvChannelTextBox.Location = new System.Drawing.Point(147, 42);
            this.programTvChannelTextBox.Name = "programTvChannelTextBox";
            this.programTvChannelTextBox.Size = new System.Drawing.Size(173, 21);
            this.programTvChannelTextBox.TabIndex = 16;
            // 
            // TvProgramEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 456);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TvProgramEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TV műsor szerkesztő";
            this.Load += new System.EventHandler(this.TvProgramEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox programAgeLimitComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox programGenresCheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox programTitleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker programEndPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker programStartPicker;
        private System.Windows.Forms.DateTimePicker programDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label programScreenTimeLabel;
        private System.Windows.Forms.Button programDeleteReserveButton;
        private System.Windows.Forms.Label programReservedLabel;
        private System.Windows.Forms.ComboBox programTvChannelTextBox;
    }
}