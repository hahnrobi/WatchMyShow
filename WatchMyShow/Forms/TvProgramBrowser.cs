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
    public partial class TvProgramBrowser : Form
    {
        public TvProgramBrowser()
        {
            InitializeComponent();
        }

        private void TvProgramBrowser_Load(object sender, EventArgs e)
        {
            using (TvContext context = new TvContext())
            {
                /*var tvChannels = context.Programs
                .OrderBy(c => c.TvChannel)
                .ToList();*/

                var tvChannels = context.Programs.GroupBy(p => p.TvChannel);
                foreach (var group in tvChannels)
                {
                    foreach (var item in group)
                    {
                        comboBox1.Items.Add(item);
                    }
                    
                }
            }
        }
    }
}
