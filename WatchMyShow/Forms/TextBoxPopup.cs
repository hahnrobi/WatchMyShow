using System;
using System.Windows.Forms;

namespace WatchMyShow.Forms
{
    public partial class TextBoxPopup : Form
    {
        public TextBoxPopup(string text)
        {
            InitializeComponent();
            Text = text;
        }
        public string Input { get; private set; }

        private void TextBoxPopup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input = inputText.Text;
        }
    }
}
