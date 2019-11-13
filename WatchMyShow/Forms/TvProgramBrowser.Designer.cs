namespace WatchMyShow.Forms
{
    partial class TvProgramBrowser
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
            this.channelSelector = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eszközökToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dátumVálasztóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szobaVálasszonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonChannelBackward = new System.Windows.Forms.Button();
            this.buttonChannelForward = new System.Windows.Forms.Button();
            this.buttonCalendarBackward = new System.Windows.Forms.Button();
            this.buttonCalendarForward = new System.Windows.Forms.Button();
            this.korhatárToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korhatarNelkulMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korhatar6MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korhatar12MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korhatar16MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korhatar18MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nézetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reserveProgramDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeProgramDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelSelector
            // 
            this.channelSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelSelector.FormattingEnabled = true;
            this.channelSelector.Location = new System.Drawing.Point(129, 56);
            this.channelSelector.Name = "channelSelector";
            this.channelSelector.Size = new System.Drawing.Size(240, 21);
            this.channelSelector.TabIndex = 0;
            this.channelSelector.SelectedIndexChanged += new System.EventHandler(this.channelSelector_SelectedIndexChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(129, 27);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(240, 20);
            this.datePicker.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eszközökToolStripMenuItem,
            this.korhatárToolStripMenuItem,
            this.nézetToolStripMenuItem,
            this.szobaVálasszonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(428, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // eszközökToolStripMenuItem
            // 
            this.eszközökToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dátumVálasztóToolStripMenuItem});
            this.eszközökToolStripMenuItem.Name = "eszközökToolStripMenuItem";
            this.eszközökToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.eszközökToolStripMenuItem.Text = "Eszközök";
            // 
            // dátumVálasztóToolStripMenuItem
            // 
            this.dátumVálasztóToolStripMenuItem.Name = "dátumVálasztóToolStripMenuItem";
            this.dátumVálasztóToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dátumVálasztóToolStripMenuItem.Text = "Dátum választó";
            this.dátumVálasztóToolStripMenuItem.Click += new System.EventHandler(this.dátumVálasztóToolStripMenuItem_Click_1);
            // 
            // szobaVálasszonToolStripMenuItem
            // 
            this.szobaVálasszonToolStripMenuItem.Name = "szobaVálasszonToolStripMenuItem";
            this.szobaVálasszonToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.szobaVálasszonToolStripMenuItem.Text = "Szoba: Válasszon!";
            this.szobaVálasszonToolStripMenuItem.Click += new System.EventHandler(this.szobaVálasszonToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 116);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 490);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dátum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tv csatorna";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(428, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingLabel
            // 
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(33, 17);
            this.loadingLabel.Text = "Kész.";
            // 
            // buttonChannelBackward
            // 
            this.buttonChannelBackward.Enabled = false;
            this.buttonChannelBackward.Location = new System.Drawing.Point(83, 55);
            this.buttonChannelBackward.Name = "buttonChannelBackward";
            this.buttonChannelBackward.Size = new System.Drawing.Size(43, 23);
            this.buttonChannelBackward.TabIndex = 7;
            this.buttonChannelBackward.Text = "<";
            this.buttonChannelBackward.UseVisualStyleBackColor = true;
            // 
            // buttonChannelForward
            // 
            this.buttonChannelForward.Enabled = false;
            this.buttonChannelForward.Location = new System.Drawing.Point(372, 55);
            this.buttonChannelForward.Name = "buttonChannelForward";
            this.buttonChannelForward.Size = new System.Drawing.Size(43, 23);
            this.buttonChannelForward.TabIndex = 8;
            this.buttonChannelForward.Text = ">";
            this.buttonChannelForward.UseVisualStyleBackColor = true;
            // 
            // buttonCalendarBackward
            // 
            this.buttonCalendarBackward.Location = new System.Drawing.Point(83, 26);
            this.buttonCalendarBackward.Name = "buttonCalendarBackward";
            this.buttonCalendarBackward.Size = new System.Drawing.Size(43, 23);
            this.buttonCalendarBackward.TabIndex = 9;
            this.buttonCalendarBackward.Text = "<";
            this.buttonCalendarBackward.UseVisualStyleBackColor = true;
            // 
            // buttonCalendarForward
            // 
            this.buttonCalendarForward.Location = new System.Drawing.Point(372, 26);
            this.buttonCalendarForward.Name = "buttonCalendarForward";
            this.buttonCalendarForward.Size = new System.Drawing.Size(43, 23);
            this.buttonCalendarForward.TabIndex = 10;
            this.buttonCalendarForward.Text = ">";
            this.buttonCalendarForward.UseVisualStyleBackColor = true;
            // 
            // korhatárToolStripMenuItem
            // 
            this.korhatárToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.korhatárToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korhatarNelkulMenuItem,
            this.korhatar6MenuItem,
            this.korhatar12MenuItem,
            this.korhatar16MenuItem,
            this.korhatar18MenuItem});
            this.korhatárToolStripMenuItem.Name = "korhatárToolStripMenuItem";
            this.korhatárToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korhatárToolStripMenuItem.Text = "Korhatár";
            // 
            // korhatarNelkulMenuItem
            // 
            this.korhatarNelkulMenuItem.Checked = true;
            this.korhatarNelkulMenuItem.CheckOnClick = true;
            this.korhatarNelkulMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.korhatarNelkulMenuItem.Name = "korhatarNelkulMenuItem";
            this.korhatarNelkulMenuItem.Size = new System.Drawing.Size(180, 22);
            this.korhatarNelkulMenuItem.Text = "Korhatár nélkül";
            // 
            // korhatar6MenuItem
            // 
            this.korhatar6MenuItem.Checked = true;
            this.korhatar6MenuItem.CheckOnClick = true;
            this.korhatar6MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.korhatar6MenuItem.Name = "korhatar6MenuItem";
            this.korhatar6MenuItem.Size = new System.Drawing.Size(180, 22);
            this.korhatar6MenuItem.Text = "6";
            // 
            // korhatar12MenuItem
            // 
            this.korhatar12MenuItem.Checked = true;
            this.korhatar12MenuItem.CheckOnClick = true;
            this.korhatar12MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.korhatar12MenuItem.Name = "korhatar12MenuItem";
            this.korhatar12MenuItem.Size = new System.Drawing.Size(180, 22);
            this.korhatar12MenuItem.Text = "12";
            // 
            // korhatar16MenuItem
            // 
            this.korhatar16MenuItem.Checked = true;
            this.korhatar16MenuItem.CheckOnClick = true;
            this.korhatar16MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.korhatar16MenuItem.Name = "korhatar16MenuItem";
            this.korhatar16MenuItem.Size = new System.Drawing.Size(180, 22);
            this.korhatar16MenuItem.Text = "16";
            // 
            // korhatar18MenuItem
            // 
            this.korhatar18MenuItem.Checked = true;
            this.korhatar18MenuItem.CheckOnClick = true;
            this.korhatar18MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.korhatar18MenuItem.Name = "korhatar18MenuItem";
            this.korhatar18MenuItem.Size = new System.Drawing.Size(180, 22);
            this.korhatar18MenuItem.Text = "18";
            // 
            // nézetToolStripMenuItem
            // 
            this.nézetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reserveProgramDisplayMenuItem,
            this.freeProgramDisplayMenuItem});
            this.nézetToolStripMenuItem.Name = "nézetToolStripMenuItem";
            this.nézetToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.nézetToolStripMenuItem.Text = "Nézet";
            // 
            // reserveProgramDisplayMenuItem
            // 
            this.reserveProgramDisplayMenuItem.Checked = true;
            this.reserveProgramDisplayMenuItem.CheckOnClick = true;
            this.reserveProgramDisplayMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reserveProgramDisplayMenuItem.Name = "reserveProgramDisplayMenuItem";
            this.reserveProgramDisplayMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reserveProgramDisplayMenuItem.Text = "Foglalt műsorok";
            // 
            // freeProgramDisplayMenuItem
            // 
            this.freeProgramDisplayMenuItem.Checked = true;
            this.freeProgramDisplayMenuItem.CheckOnClick = true;
            this.freeProgramDisplayMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.freeProgramDisplayMenuItem.Name = "freeProgramDisplayMenuItem";
            this.freeProgramDisplayMenuItem.Size = new System.Drawing.Size(180, 22);
            this.freeProgramDisplayMenuItem.Text = "Szabad műsorok";
            // 
            // TvProgramBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 616);
            this.Controls.Add(this.buttonCalendarForward);
            this.Controls.Add(this.buttonCalendarBackward);
            this.Controls.Add(this.buttonChannelForward);
            this.Controls.Add(this.buttonChannelBackward);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.channelSelector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TvProgramBrowser";
            this.Text = "TvProgramBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TvProgramBrowser_FormClosing);
            this.Load += new System.EventHandler(this.TvProgramBrowser_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox channelSelector;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eszközökToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dátumVálasztóToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loadingLabel;
        private System.Windows.Forms.ToolStripMenuItem szobaVálasszonToolStripMenuItem;
        private System.Windows.Forms.Button buttonChannelBackward;
        private System.Windows.Forms.Button buttonChannelForward;
        private System.Windows.Forms.Button buttonCalendarBackward;
        private System.Windows.Forms.Button buttonCalendarForward;
        private System.Windows.Forms.ToolStripMenuItem korhatárToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korhatarNelkulMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korhatar6MenuItem;
        private System.Windows.Forms.ToolStripMenuItem korhatar12MenuItem;
        private System.Windows.Forms.ToolStripMenuItem korhatar16MenuItem;
        private System.Windows.Forms.ToolStripMenuItem korhatar18MenuItem;
        private System.Windows.Forms.ToolStripMenuItem nézetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserveProgramDisplayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeProgramDisplayMenuItem;
    }
}