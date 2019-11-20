﻿namespace WatchMyShow.Forms
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
            this.ageLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reservedRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.channelSelector = new System.Windows.Forms.CheckedListBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resetFilterButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.programList.FullRowSelect = true;
            this.programList.GridLines = true;
            this.programList.HideSelection = false;
            this.programList.Location = new System.Drawing.Point(3, 103);
            this.programList.MultiSelect = false;
            this.programList.Name = "programList";
            this.programList.Size = new System.Drawing.Size(618, 105);
            this.programList.TabIndex = 0;
            this.programList.UseCompatibleStateImageBehavior = false;
            this.programList.View = System.Windows.Forms.View.Details;
            this.programList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.programList_ColumnClick);
            this.programList.SelectedIndexChanged += new System.EventHandler(this.programList_SelectedIndexChanged);
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
            // ageLimit
            // 
            this.ageLimit.DisplayIndex = 5;
            this.ageLimit.Text = "Korhatár";
            // 
            // endTime
            // 
            this.endTime.DisplayIndex = 4;
            this.endTime.Text = "Vége";
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
            this.panel1.Controls.Add(this.resetFilterButton);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.FilterButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 94);
            this.panel1.TabIndex = 1;
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
            // channelSelector
            // 
            this.channelSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelSelector.FormattingEnabled = true;
            this.channelSelector.Location = new System.Drawing.Point(3, 16);
            this.channelSelector.Name = "channelSelector";
            this.channelSelector.Size = new System.Drawing.Size(146, 63);
            this.channelSelector.TabIndex = 22;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(540, 61);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(75, 23);
            this.FilterButton.TabIndex = 21;
            this.FilterButton.Text = "Szűrés";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Innen:";
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
            // datePickerStart
            // 
            this.datePickerStart.Location = new System.Drawing.Point(59, 19);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(240, 20);
            this.datePickerStart.TabIndex = 12;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerStart_ValueChanged);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Location = new System.Drawing.Point(59, 45);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(240, 20);
            this.datePickerEnd.TabIndex = 24;
            this.datePickerEnd.ValueChanged += new System.EventHandler(this.datePickerEnd_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Eddig:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datePickerStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.datePickerEnd);
            this.groupBox2.Location = new System.Drawing.Point(167, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 79);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dátum";
            // 
            // resetFilterButton
            // 
            this.resetFilterButton.Location = new System.Drawing.Point(526, 32);
            this.resetFilterButton.Name = "resetFilterButton";
            this.resetFilterButton.Size = new System.Drawing.Size(89, 23);
            this.resetFilterButton.TabIndex = 27;
            this.resetFilterButton.Text = "Szűrő törlése";
            this.resetFilterButton.UseVisualStyleBackColor = true;
            this.resetFilterButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingLabel
            // 
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(33, 17);
            this.loadingLabel.Text = "Kész.";
            // 
            // TvProgramManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 161);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 200);
            this.Name = "TvProgramManageForm";
            this.Text = "TvProgramManageForm";
            this.Load += new System.EventHandler(this.TvProgramManageForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox channelSelector;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetFilterButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loadingLabel;
    }
}