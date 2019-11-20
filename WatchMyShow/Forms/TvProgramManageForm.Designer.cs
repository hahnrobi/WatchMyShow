namespace WatchMyShow.Forms
{
    partial class TvProgramManageForm
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
            this.programList = new System.Windows.Forms.ListView();
            this.programTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.programDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ageLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reservedRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.channelSelector = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // programList
            // 
            this.programList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.programTitle,
            this.tvChannel,
            this.programDate,
            this.startTime,
            this.ageLimit,
            this.endTime,
            this.reservedRoom});
            this.programList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programList.HideSelection = false;
            this.programList.Location = new System.Drawing.Point(3, 103);
            this.programList.Name = "programList";
            this.programList.Size = new System.Drawing.Size(618, 105);
            this.programList.TabIndex = 0;
            this.programList.UseCompatibleStateImageBehavior = false;
            this.programList.View = System.Windows.Forms.View.Details;
            // 
            // programTitle
            // 
            this.programTitle.Text = "Műsor neve";
            this.programTitle.Width = 201;
            // 
            // tvChannel
            // 
            this.tvChannel.Text = "TV csatorna";
            // 
            // programDate
            // 
            this.programDate.Text = "Dátum";
            this.programDate.Width = 112;
            // 
            // startTime
            // 
            this.startTime.Text = "Kezdés";
            // 
            // endTime
            // 
            this.endTime.DisplayIndex = 4;
            this.endTime.Text = "Vége";
            // 
            // ageLimit
            // 
            this.ageLimit.DisplayIndex = 5;
            this.ageLimit.Text = "Korhatár";
            // 
            // reservedRoom
            // 
            this.reservedRoom.Text = "Foglalva";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.programList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 161);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 94);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-103, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tv csatorna";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-103, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dátum:";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(279, 3);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(240, 20);
            this.datePicker.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dátum:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // channelSelector
            // 
            this.channelSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelSelector.FormattingEnabled = true;
            this.channelSelector.Location = new System.Drawing.Point(3, 16);
            this.channelSelector.Name = "channelSelector";
            this.channelSelector.Size = new System.Drawing.Size(146, 63);
            this.channelSelector.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.channelSelector);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 82);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Csatorna";
            // 
            // TvProgramManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 200);
            this.Name = "TvProgramManageForm";
            this.Text = "TvProgramManageForm";
            this.Load += new System.EventHandler(this.TvProgramManageForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView programList;
        private System.Windows.Forms.ColumnHeader programTitle;
        private System.Windows.Forms.ColumnHeader tvChannel;
        private System.Windows.Forms.ColumnHeader programDate;
        private System.Windows.Forms.ColumnHeader startTime;
        private System.Windows.Forms.ColumnHeader ageLimit;
        private System.Windows.Forms.ColumnHeader endTime;
        private System.Windows.Forms.ColumnHeader reservedRoom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox channelSelector;
    }
}