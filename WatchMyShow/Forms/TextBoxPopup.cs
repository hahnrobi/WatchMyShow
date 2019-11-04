using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchMyShow.Forms
{
    public partial class TextBoxPopup : Form
    {
        public TextBoxPopup(string text)
        {
            InitializeComponent();
            this.Text = text;
        }
        public string Input { get; private set; }

        private void TextBoxPopup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Input = inputText.Text;
        }
    }
}
